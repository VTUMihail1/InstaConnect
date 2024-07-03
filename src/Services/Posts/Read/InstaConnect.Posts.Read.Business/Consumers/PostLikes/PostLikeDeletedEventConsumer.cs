using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Contracts.PostLikes;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.PostLikes;

internal class PostLikeDeletedEventConsumer : IConsumer<PostLikeDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostLikeRepository _postLikeRepository;

    public PostLikeDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IPostLikeRepository postLikeRepository)
    {
        _unitOfWork = unitOfWork;
        _postLikeRepository = postLikeRepository;
    }

    public async Task Consume(ConsumeContext<PostLikeDeletedEvent> context)
    {
        var existingPostLike = await _postLikeRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingPostLike == null)
        {
            return;
        }

        _postLikeRepository.Delete(existingPostLike);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
