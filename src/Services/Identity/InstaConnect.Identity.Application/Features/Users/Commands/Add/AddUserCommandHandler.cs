using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand, UserCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEventPublisher _eventPublisher;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenPublisher _emailConfirmationTokenPublisher;

    public AddUserCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenPublisher emailConfirmationTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _applicationMapper = applicationMapper;
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
        var user = _applicationMapper.Map<User>((passwordHash, request));

        if (request.ProfileImage != null)
        {
            var imageUploadModel = _applicationMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);

            _applicationMapper.Map(imageUploadResult, user);
        }

        _userWriteRepository.Add(user);

        var userCreatedEvent = _applicationMapper.Map<UserCreatedEvent>(user);
        await _eventPublisher.PublishAsync(userCreatedEvent, cancellationToken);

        var createEmailConfirmationTokenModel = _applicationMapper.Map<CreateEmailConfirmationTokenModel>(user);
        await _emailConfirmationTokenPublisher.PublishEmailConfirmationTokenAsync(createEmailConfirmationTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _applicationMapper.Map<UserCommandViewModel>(user);

        return accountCommandViewModel;
    }
}
