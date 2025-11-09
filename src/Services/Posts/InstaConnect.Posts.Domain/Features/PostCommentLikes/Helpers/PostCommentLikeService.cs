using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
internal class PostCommentLikeService : IPostCommentLikeService
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IPostCommentLikeFactory _postCommentLikeFactory;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public PostCommentLikeService(
        IEventPublisher eventPublisher,
        IPostRepository postRepository,
        IUserRepository userRepository,
        IApplicationMapper applicationMapper,
        IPostCommentRepository postCommentRepository,
        IPostCommentLikeFactory postCommentLikeFactory,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _eventPublisher = eventPublisher;
        _postRepository = postRepository;
        _userRepository = userRepository;
        _applicationMapper = applicationMapper;
        _postCommentRepository = postCommentRepository;
        _postCommentLikeFactory = postCommentLikeFactory;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task<PostCommentLikeCollection> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(
            query.Filter.Id,
            query.Filter.CommentId,
            cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(query.Filter.Id, query.Filter.CommentId);
        }

        var existingPostCommentLikeCollection = await _postCommentLikeRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingPostCommentLikeCollection;
    }

    public async Task<PostCommentLike> GetByIdAsync(GetPostCommentLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(query.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(query.Id, query.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(query.Id, query.CommentId);
        }

        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(
            query.Id,
            query.CommentId,
            query.UserId,
            query.Include,
            cancellationToken);

        if (existingPostCommentLike.IsNull())
        {
            throw new PostCommentLikeNotFoundException(query.Id, query.CommentId, query.UserId);
        }

        return existingPostCommentLike!;
    }

    public async Task<PostCommentLike> AddAsync(AddPostCommentLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(command.Id, command.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id, command.CommentId);
        }

        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.UserId);
        }

        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(
            command.Id,
            command.CommentId,
            command.UserId,
            cancellationToken);

        if (existingPostCommentLike.IsNotNull())
        {
            throw new PostCommentLikeAlreadyExistsException(
                command.Id,
                command.CommentId,
                command.UserId);
        }

        var postCommentLike = _postCommentLikeFactory.Create(command.Id, command.CommentId, command.UserId);
        await _postCommentLikeRepository.AddAsync(postCommentLike, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentLikeAddedEventRequest>(postCommentLike);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postCommentLike;
    }

    public async Task DeleteAsync(DeletePostCommentLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(command.Id, command.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id, command.CommentId);
        }

        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(
            command.Id,
            command.CommentId,
            command.UserId,
            cancellationToken);

        if (existingPostCommentLike.IsNull())
        {
            throw new PostCommentLikeNotFoundException(command.Id, command.CommentId, command.UserId);
        }

        await _postCommentLikeRepository.DeleteAsync(existingPostCommentLike!, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentLikeDeletedEventRequest>(existingPostCommentLike!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
