using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
internal class PostLikeService : IPostLikeService
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    private readonly IPostLikeFactory _postLikeFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostLikeRepository _postLikeRepository;

    public PostLikeService(
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IPostRepository postRepository,
        IPostLikeFactory postLikeFactory,
        IApplicationMapper applicationMapper,
        IPostLikeRepository postLikeRepository)
    {
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _postRepository = postRepository;
        _postLikeFactory = postLikeFactory;
        _applicationMapper = applicationMapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var existingPostLikeCollection = await _postLikeRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingPostLikeCollection;
    }

    public async Task<PostLike> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(query.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id);
        }

        var existingPostLike = await _postLikeRepository.GetByIdAsync(
            query.Id,
            query.UserId,
            query.Include,
            cancellationToken);

        if (existingPostLike.IsNull())
        {
            throw new PostLikeNotFoundException(query.Id, query.UserId);
        }

        return existingPostLike!;
    }

    public async Task<PostLike> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.UserId);
        }

        var existingPostLike = await _postLikeRepository.GetByIdAsync(command.Id, command.UserId, cancellationToken);

        if (existingPostLike.IsNotNull())
        {
            throw new PostLikeAlreadyExistsException(command.Id, command.UserId);
        }

        var postLike = _postLikeFactory.Create(command.Id, command.UserId);
        await _postLikeRepository.AddAsync(postLike, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostLikeAddedEventRequest>(postLike);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postLike;
    }

    public async Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingPostLike = await _postLikeRepository.GetByIdAsync(command.Id, command.UserId, cancellationToken);

        if (existingPostLike.IsNull())
        {
            throw new PostLikeNotFoundException(command.Id, command.UserId);
        }

        await _postLikeRepository.DeleteAsync(existingPostLike!, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostLikeDeletedEventRequest>(existingPostLike!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
