namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

internal class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowWriteRepository _followWriteRepository;

    public DeleteFollowCommandHandler(
        IUnitOfWork unitOfWork,
        IFollowWriteRepository followWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _followWriteRepository = followWriteRepository;
    }

    public async Task Handle(
        DeleteFollowCommand request,
        CancellationToken cancellationToken)
    {
        var existingFollow = await _followWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingFollow == null)
        {
            throw new FollowNotFoundException();
        }

        if (request.CurrentUserId != existingFollow.FollowerId)
        {
            throw new UserForbiddenException();
        }

        _followWriteRepository.Delete(existingFollow);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
