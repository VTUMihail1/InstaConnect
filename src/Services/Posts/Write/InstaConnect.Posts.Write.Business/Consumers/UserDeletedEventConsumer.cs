using AutoMapper;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Posts.Write.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Consumers;
internal class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public UserDeletedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        IPostLikeRepository postLikeRepository,
        IPostCommentRepository postCommentRepository,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _postLikeRepository = postLikeRepository;
        _postCommentRepository = postCommentRepository;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        await DeletePostsByUserIdAsync(context.Message, context.CancellationToken);
        await DeletePostLikesByUserIdAsync(context.Message, context.CancellationToken);
        await DeletePostCommentsByUserIdAsync(context.Message, context.CancellationToken);
        await DeletePostCommentLikesByUserIdAsync(context.Message, context.CancellationToken);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }

    private async Task DeletePostsByUserIdAsync(UserDeletedEvent userDeletedEvent, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostFilteredCollectionQuery>(userDeletedEvent);
        var existingPosts = await _postRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        _postRepository.DeleteRange(existingPosts.Items);
    }
    private async Task DeletePostLikesByUserIdAsync(UserDeletedEvent userDeletedEvent, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostLikeFilteredCollectionQuery>(userDeletedEvent);
        var existingPostLikes = await _postLikeRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        _postLikeRepository.DeleteRange(existingPostLikes.Items);
    }

    private async Task DeletePostCommentsByUserIdAsync(UserDeletedEvent userDeletedEvent, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostCommentFilteredCollectionQuery>(userDeletedEvent);
        var existingPostComments = await _postCommentRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        _postCommentRepository.DeleteRange(existingPostComments.Items);
    }

    private async Task DeletePostCommentLikesByUserIdAsync(UserDeletedEvent userDeletedEvent, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostCommentLikeFilteredCollectionQuery>(userDeletedEvent);
        var existingPostComments = await _postCommentLikeRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        _postCommentLikeRepository.DeleteRange(existingPostComments.Items);
    }
}
