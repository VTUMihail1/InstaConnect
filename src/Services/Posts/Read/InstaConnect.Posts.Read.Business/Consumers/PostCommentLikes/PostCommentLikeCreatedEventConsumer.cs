using AutoMapper;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.PostCommentLikes;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.PostCommentLikes;

internal class PostCommentLikeCreatedEventConsumer : IConsumer<PostCommentLikeCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public PostCommentLikeCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task Consume(ConsumeContext<PostCommentLikeCreatedEvent> context)
    {
        var postCommentLike = _mapper.Map<PostCommentLike>(context.Message);
        _postCommentLikeRepository.Add(postCommentLike);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
