namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postWriteRepository;

    public DeletePostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postWriteRepository = postWriteRepository;
    }

    public async Task Handle(
        DeletePostCommand request, 
        CancellationToken cancellationToken)
    {
        var post = await _postWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != post.UserId)
        {
            throw new UserForbiddenException();
        }

        _postWriteRepository.Delete(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
