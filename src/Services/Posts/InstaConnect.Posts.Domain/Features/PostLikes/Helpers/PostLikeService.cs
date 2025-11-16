using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
internal class PostLikeService : IPostLikeService
{
    private readonly IPostRepository _repository;
    private readonly IPostLikeFactory _likeFactory;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IPostLikeRepository _likeRepository;
    private readonly IApplicationMapper _applicationMapper;

    public PostLikeService(
        IPostRepository repository,
        IPostLikeFactory likeFactory,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IPostLikeRepository likeRepository,
        IApplicationMapper applicationMapper)
    {
        _repository = repository;
        _likeFactory = likeFactory;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _likeRepository = likeRepository;
        _applicationMapper = applicationMapper;
    }

    public async Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var existingPostLikeCollection = await _likeRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingPostLikeCollection;
    }

    public async Task<PostLike> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(query.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id.Id);
        }

        var existingPostLike = await _likeRepository.GetByIdAsync(
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
        var existingPost = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.UserId);
        }

        var postLike = _likeFactory.Create(command.Id, command.UserId);
        var existingPostLike = await _likeRepository.GetByIdAsync(postLike.Id, cancellationToken);

        if (existingPostLike.IsNotNull())
        {
            throw new PostLikeAlreadyExistsException(postLike.Id);
        }

        await _likeRepository.AddAsync(postLike, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostLikeAddedEventRequest>(postLike);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postLike;
    }

    public async Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id.Id);
        }

        var existingPostLike = await _likeRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPostLike.IsNull())
        {
            throw new PostLikeNotFoundException(command.Id);
        }

        await _likeRepository.DeleteAsync(existingPostLike!, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostLikeDeletedEventRequest>(existingPostLike!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
