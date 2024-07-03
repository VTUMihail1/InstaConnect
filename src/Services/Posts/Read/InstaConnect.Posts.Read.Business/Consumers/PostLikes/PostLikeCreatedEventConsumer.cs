using AutoMapper;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.PostLikes;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.PostLikes;

internal class PostLikeCreatedEventConsumer : IConsumer<PostLikeCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostLikeRepository _postLikeRepository;

    public PostLikeCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostLikeRepository postLikeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postLikeRepository = postLikeRepository;
    }

    public async Task Consume(ConsumeContext<PostLikeCreatedEvent> context)
    {
        var postLike = _mapper.Map<PostLike>(context.Message);
        _postLikeRepository.Add(postLike);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
