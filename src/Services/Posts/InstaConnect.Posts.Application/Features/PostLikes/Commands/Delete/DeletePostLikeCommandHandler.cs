namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

internal class DeletePostLikeCommandHandler : ICommandHandler<DeletePostLikeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostLikeService _postLikeService;
    private readonly IPostWriteRepository _postWriteRepository;

    public DeletePostLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IPostLikeService postLikeService,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postLikeService = postLikeService;
        _postWriteRepository = postWriteRepository;
    }

    public async Task Handle(DeletePostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        await _postLikeService.DeleteAsync(existingPost, request.Id, request.CurrentUserId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
