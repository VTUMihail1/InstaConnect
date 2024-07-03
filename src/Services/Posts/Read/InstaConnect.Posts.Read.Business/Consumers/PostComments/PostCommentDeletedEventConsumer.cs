using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.PostComments;

internal class PostCommentDeletedEventConsumer : IConsumer<PostCommentDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentRepository _postCommentRepository;

    public PostCommentDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IPostCommentRepository postCommentRepository)
    {
        _unitOfWork = unitOfWork;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Consume(ConsumeContext<PostCommentDeletedEvent> context)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingPostComment == null)
        {
            return;
        }

        _postCommentRepository.Delete(existingPostComment);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
