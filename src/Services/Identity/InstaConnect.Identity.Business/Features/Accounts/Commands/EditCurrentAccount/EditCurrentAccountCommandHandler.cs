using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;

public class EditCurrentAccountCommandHandler : ICommandHandler<EditCurrentAccountCommand, AccountCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public EditCurrentAccountCommandHandler(
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

    public async Task<AccountCommandViewModel> Handle(
        EditCurrentAccountCommand request,
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
            throw new AccountNameAlreadyTakenException();
        }

        _instaConnectMapper.Map(request, existingUserById);

        if (request.ProfileImage != null)
        {
            var imageUploadModel = _instaConnectMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);
            _instaConnectMapper.Map(imageUploadResult, existingUserById);
        }

        _userWriteRepository.Update(existingUserById);

        var userUpdatedEvent = _instaConnectMapper.Map<UserUpdatedEvent>(existingUserById);
        await _eventPublisher.PublishAsync(userUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<AccountCommandViewModel>(existingUserById);

        return accountCommandViewModel;
    }
}
