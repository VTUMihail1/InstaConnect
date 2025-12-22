using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
internal class PostLikeService : IPostLikeService
{
    private readonly IPostRepository _postRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IPostLikeFactory _postLikeFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostLikeRepository _postLikeRepository;

    public PostLikeService(
        IPostRepository postRepository,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IPostLikeFactory postLikeFactory,
        IApplicationMapper applicationMapper,
        IPostLikeRepository postLikeRepository)
    {
        _postRepository = postRepository;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
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
        var existingPost = await _postRepository.GetByIdAsync(query.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id.Id);
        }

        var existingPostLike = await _postLikeRepository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

        if (existingPostLike.IsNull())
        {
            throw new PostLikeNotFoundException(query.Id);
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

        var postLike = _postLikeFactory.Create(command.Id, command.UserId);
        var existingPostLike = await _postLikeRepository.GetByIdAsync(postLike.Id, cancellationToken);

        if (existingPostLike.IsNotNull())
        {
            throw new PostLikeAlreadyExistsException(postLike.Id);
        }

        await _postLikeRepository.AddAsync(postLike, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostLikeAddedEventRequest>(postLike);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postLike;
    }

    public async Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id.Id);
        }

        var existingPostLike = await _postLikeRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPostLike.IsNull())
        {
            throw new PostLikeNotFoundException(command.Id);
        }

        await _postLikeRepository.DeleteAsync(existingPostLike!, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostLikeDeletedEventRequest>(existingPostLike!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
