using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Read.Consumers.Posts;

internal class PostDeletedEventConsumer : IConsumer<PostDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;

    public PostDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IPostRepository postRepository)
    {
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
    }

    public async Task Consume(ConsumeContext<PostDeletedEvent> context)
    {
        var existingPost = await _postRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingPost == null)
        {
            return;
        }

        _postRepository.Delete(existingPost);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
