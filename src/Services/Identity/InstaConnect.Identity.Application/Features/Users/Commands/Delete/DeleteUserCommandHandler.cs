using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public DeleteUserCommandHandler(
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        _userWriteRepository.Delete(existingUser);

        var userDeletedEvent = _applicationMapper.Map<UserDeletedEvent>(existingUser);
        await _eventPublisher.PublishAsync(userDeletedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
