namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentLikeWriteRepository _postCommentLikeWriteRepository;

    public DeletePostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IPostCommentLikeWriteRepository postCommentLikeWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postCommentLikeWriteRepository = postCommentLikeWriteRepository;
    }

    public async Task Handle(
        DeletePostCommentLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostCommentLike = await _postCommentLikeWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostCommentLike == null)
        {
            throw new PostCommentLikeNotFoundException();
        }

        if (request.CurrentUserId != existingPostCommentLike.UserId)
        {
            throw new UserForbiddenException();
        }

        _postCommentLikeWriteRepository.Delete(existingPostCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
