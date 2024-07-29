using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;

public class DeleteCurrentAccountCommandHandler : ICommandHandler<DeleteCurrentAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public DeleteCurrentAccountCommandHandler(
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Handle(
        DeleteCurrentAccountCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        _userWriteRepository.Delete(existingUser);

        var userDeletedEvent = _instaConnectMapper.Map<UserDeletedEvent>(existingUser);
        await _eventPublisher.PublishAsync(userDeletedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
