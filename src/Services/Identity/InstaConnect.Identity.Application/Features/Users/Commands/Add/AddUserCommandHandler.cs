using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Application.Models;
using InstaConnect.Shared.Common.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand, UserCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenPublisher _emailConfirmationTokenPublisher;

    public AddUserCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenPublisher emailConfirmationTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenPublisher = emailConfirmationTokenPublisher;
    }

    public async Task<UserCommandViewModel> Handle(
        AddUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingEmailUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingEmailUser != null)
        {
            throw new UserEmailAlreadyTakenException();
        }

        var existingNameUser = await _userWriteRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingNameUser != null)
        {
            throw new UserNameAlreadyTakenException();
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

        var createEmailConfirmationTokenModel = _instaConnectMapper.Map<CreateEmailConfirmationTokenModel>(user);
        await _emailConfirmationTokenPublisher.PublishEmailConfirmationTokenAsync(createEmailConfirmationTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<UserCommandViewModel>(user);

        return accountCommandViewModel;
    }
}
