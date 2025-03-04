namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public DeletePostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IPostWriteRepository postWriteRepository,
        IPostCommentLikeService postCommentLikeService)
    {
        _unitOfWork = unitOfWork;
        _postWriteRepository = postWriteRepository;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task Handle(
        DeletePostCommentLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        await _postCommentLikeService.DeleteAsync(existingPost, request.PostCommentId, request.Id, request.CurrentUserId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
