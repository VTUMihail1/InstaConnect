using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ITokenRepository _tokenRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public RegisterAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenGenerator tokenGenerator,
        ITokenRepository tokenRepository,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
        _tokenRepository = tokenRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var existingEmailUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingEmailUser != null)
        {
            throw new AccountEmailAlreadyTakenException();
        }

        var existingNameUser = await _userRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingNameUser != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        var user = _mapper.Map<User>(request);
        var passwordHash = _passwordHasher.Hash(request.Password);
        _mapper.Map(passwordHash, user);

        if (request.ProfileImage != null)
        {
            var imageUploadModel = _mapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);

            _mapper.Map(imageUploadResult, user);
        }

        _userRepository.Add(user);

        var userCreatedEvent = _mapper.Map<UserCreatedEvent>(user);
        await _publishEndpoint.Publish(userCreatedEvent, cancellationToken);

        var createAccountTokenModel = _mapper.Map<CreateAccountTokenModel>(user);
        var token = _tokenGenerator.GenerateEmailConfirmationToken(createAccountTokenModel);
        _tokenRepository.Add(token);

        var userConfirmEmailTokenCreatedEvent = _mapper.Map<UserConfirmEmailTokenCreatedEvent>(token);
        _mapper.Map(user, userConfirmEmailTokenCreatedEvent);
        await _publishEndpoint.Publish(userConfirmEmailTokenCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
