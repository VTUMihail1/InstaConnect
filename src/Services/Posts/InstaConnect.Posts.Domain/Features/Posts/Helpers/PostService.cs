using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;
internal class PostService : IPostService
{
    private readonly IPostFactory _factory;
    private readonly IPostRepository _repository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;

    public PostService(
        IPostFactory factory,
        IPostRepository repository,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper)
    {
        _factory = factory;
        _repository = repository;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
    }

    public async Task<PostCollection> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken)
    {
        var existingPostCollection = await _repository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingPostCollection;
    }

    public async Task<Post> GetByIdAsync(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id);
        }

        return existingPost!;
    }

    public async Task<Post> AddAsync(AddPostCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.UserId);
        }

        var post = _factory.Create(command.UserId, command.Title, command.Content);
        await _repository.AddAsync(post, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostAddedEventRequest>(post);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return post;
    }

    public async Task<Post> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        if (existingPost!.IsNotOwnedByUser(command.UserId))
        {
            throw new PostForbiddenException(command.Id, command.UserId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingPost.Update(command.Title, command.Content, utcNow);
        await _repository.UpdateAsync(existingPost, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostUpdatedEventRequest>(existingPost);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return existingPost;
    }

    public async Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        if (existingPost!.IsNotOwnedByUser(command.UserId))
        {
            throw new PostForbiddenException(command.Id, command.UserId);
        }

        await _repository.DeleteAsync(existingPost, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostDeletedEventRequest>(existingPost);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
