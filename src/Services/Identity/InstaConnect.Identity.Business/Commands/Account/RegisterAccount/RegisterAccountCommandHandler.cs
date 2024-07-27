using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand, AccountCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public RegisterAccountCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        ITokenGenerator tokenGenerator,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<AccountCommandViewModel> Handle(
        RegisterAccountCommand request, 
        CancellationToken cancellationToken)
    {
        var existingEmailUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingEmailUser != null)
        {
            throw new AccountEmailAlreadyTakenException();
        }

        var existingNameUser = await _userWriteRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingNameUser != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        var passwordHash = _passwordHasher.Hash(request.Password);
        var user = _instaConnectMapper.Map<User>((passwordHash, request));

        if (request.ProfileImage != null)
        {
            var imageUploadModel = _instaConnectMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);

            _instaConnectMapper.Map(imageUploadResult, user);
        }

        _userWriteRepository.Add(user);

        var userCreatedEvent = _instaConnectMapper.Map<UserCreatedEvent>(user);
        await _eventPublisher.PublishAsync(userCreatedEvent, cancellationToken);

        var createAccountTokenModel = _instaConnectMapper.Map<CreateAccountTokenModel>(user);
        var token = _tokenGenerator.GenerateEmailConfirmationToken(createAccountTokenModel);
        var userConfirmEmailTokenCreatedEvent = _instaConnectMapper.Map<UserConfirmEmailTokenCreatedEvent>((token, user));

        _instaConnectMapper.Map(user, userConfirmEmailTokenCreatedEvent);
        await _eventPublisher.PublishAsync(userConfirmEmailTokenCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<AccountCommandViewModel>(user);

        return accountCommandViewModel;
    }
}
