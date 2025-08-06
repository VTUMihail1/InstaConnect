using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Update;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IEventPublisher _eventPublisher;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public UpdateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IEventPublisher eventPublisher,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _eventPublisher = eventPublisher;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<UserCommandViewModel> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserById = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUserById == null)
        {
            throw new UserNotFoundException();
        }

        var existingUserByName = await _userWriteRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingUserById.UserName != request.UserName && existingUserByName != null)
        {
            throw new UserNameAlreadyTakenException();
        }

        _applicationMapper.Map(request, existingUserById);

        if (request.ProfileImageFile != null)
        {
            var imageUploadModel = _applicationMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);
            _applicationMapper.Map(imageUploadResult, existingUserById);
        }

        _userWriteRepository.Update(existingUserById);

        var userUpdatedEvent = _applicationMapper.Map<UserUpdatedEventRequest>(existingUserById);
        await _eventPublisher.PublishAsync(userUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _applicationMapper.Map<UserCommandViewModel>(existingUserById);

        return accountCommandViewModel;
    }
}
