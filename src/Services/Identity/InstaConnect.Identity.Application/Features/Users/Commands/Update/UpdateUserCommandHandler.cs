using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Application.Models;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Update;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public UpdateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
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

        _instaConnectMapper.Map(request, existingUserById);

        if (request.ProfileImageFile != null)
        {
            var imageUploadModel = _instaConnectMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);
            _instaConnectMapper.Map(imageUploadResult, existingUserById);
        }

        _userWriteRepository.Update(existingUserById);

        var userUpdatedEvent = _instaConnectMapper.Map<UserUpdatedEvent>(existingUserById);
        await _eventPublisher.PublishAsync(userUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<UserCommandViewModel>(existingUserById);

        return accountCommandViewModel;
    }
}
