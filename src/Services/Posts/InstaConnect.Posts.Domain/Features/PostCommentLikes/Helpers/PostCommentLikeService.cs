using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
internal class PostCommentLikeService : IPostCommentLikeService
{
    private readonly IPostRepository _repository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentRepository _commentRepository;
    private readonly IPostCommentLikeFactory _commentLikeFactory;
    private readonly IPostCommentLikeRepository _commentLikeRepository;

    public PostCommentLikeService(
        IPostRepository repository,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IApplicationMapper applicationMapper,
        IPostCommentRepository commentRepository,
        IPostCommentLikeFactory commentLikeFactory,
        IPostCommentLikeRepository commentLikeRepository)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _applicationMapper = applicationMapper;
        _commentRepository = commentRepository;
        _commentLikeFactory = commentLikeFactory;
        _commentLikeRepository = commentLikeRepository;
    }

    public async Task<PostCommentLikeCollection> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(query.Filter.CommentId.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Filter.CommentId.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(
            query.Filter.CommentId,
            cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(query.Filter.CommentId);
        }

        var existingPostCommentLikeCollection = await _commentLikeRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingPostCommentLikeCollection;
    }

    public async Task<PostCommentLike> GetByIdAsync(GetPostCommentLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(query.Id.CommentId.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id.CommentId.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(query.Id.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(query.Id.CommentId);
        }

        var existingPostCommentLike = await _commentLikeRepository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

        if (existingPostCommentLike.IsNull())
        {
            throw new PostCommentLikeNotFoundException(query.Id);
        }

        return existingPostCommentLike!;
    }

    public async Task<PostCommentLike> AddAsync(AddPostCommentLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.CommentId.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.CommentId.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(command.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.CommentId);
        }

        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.UserId);
        }

        var postCommentLike = _commentLikeFactory.Create(command.CommentId, command.UserId);
        var existingPostCommentLike = await _commentLikeRepository.GetByIdAsync(
            postCommentLike.Id,
            cancellationToken);

        if (existingPostCommentLike.IsNotNull())
        {
            throw new PostCommentLikeAlreadyExistsException(postCommentLike.Id);
        }

        await _commentLikeRepository.AddAsync(postCommentLike, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentLikeAddedEventRequest>(postCommentLike);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postCommentLike;
    }

    public async Task DeleteAsync(DeletePostCommentLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.Id.CommentId.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id.CommentId.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(command.Id.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id.CommentId);
        }

        var existingPostCommentLike = await _commentLikeRepository.GetByIdAsync(
            command.Id,
            cancellationToken);

        if (existingPostCommentLike.IsNull())
        {
            throw new PostCommentLikeNotFoundException(command.Id);
        }

        await _commentLikeRepository.DeleteAsync(existingPostCommentLike!, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentLikeDeletedEventRequest>(existingPostCommentLike!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
