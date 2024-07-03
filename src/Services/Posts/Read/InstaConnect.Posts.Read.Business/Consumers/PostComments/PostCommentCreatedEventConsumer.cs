using AutoMapper;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.PostComments;

internal class PostCommentCreatedEventConsumer : IConsumer<PostCommentCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentRepository _postCommentRepository;

    public PostCommentCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Consume(ConsumeContext<PostCommentCreatedEvent> context)
    {
        var postComment = _mapper.Map<PostComment>(context.Message);
        _postCommentRepository.Add(postComment);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
