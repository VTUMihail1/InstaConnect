using AutoMapper;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Read.Consumers.PostComments;

internal class PostCommentUpdatedEventConsumer : IConsumer<PostCommentUpdatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentRepository _postCommentRepository;

    public PostCommentUpdatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Consume(ConsumeContext<PostCommentUpdatedEvent> context)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingPostComment == null)
        {
            return;
        }

        _mapper.Map(context.Message, existingPostComment);
        _postCommentRepository.Update(existingPostComment);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
