using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Contracts.PostCommentLikes;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.PostCommentLikes;

internal class PostCommentLikeDeletedEventConsumer : IConsumer<PostCommentLikeDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public PostCommentLikeDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _unitOfWork = unitOfWork;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task Consume(ConsumeContext<PostCommentLikeDeletedEvent> context)
    {
        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingPostCommentLike == null)
        {
            return;
        }

        _postCommentLikeRepository.Delete(existingPostCommentLike);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
