using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers;
internal class PostService : IPostService
{
    private readonly IPostFactory _postFactory;
    private readonly IEventPublisher _eventPublisher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public PostService(
        IPostFactory postFactory,
        IEventPublisher eventPublisher,
        IDateTimeProvider dateTimeProvider,
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository,
        IPostWriteRepository postWriteRepository,
        IUserWriteRepository userWriteRepository)
    {
        _postFactory = postFactory;
        _eventPublisher = eventPublisher;
        _dateTimeProvider = dateTimeProvider;
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
        _postWriteRepository = postWriteRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<PostQueryCollection> GetAllAsync(PostQueryParameters parameters, CancellationToken cancellationToken)
    {
        var posts = await _postReadRepository.GetAllAsync(parameters, cancellationToken);

        return posts;
    }

    public async Task<Post> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var post = await _postReadRepository.GetByIdAsync(id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        return post;
    }

    public async Task<Post> AddAsync(
        string userId,
        string title,
        string content,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.GetByIdAsync(userId, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException();
        }

        var post = _postFactory.Get(userId, title, content);
        _postWriteRepository.Add(post);

        var integrationEvent = _instaConnectMapper.Map<AddedPostEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }

    public async Task<Post> UpdateAsync(
        string id,
        string userId,
        string title,
        string content,
        CancellationToken cancellationToken)
    {
        var post = await _postWriteRepository.GetByIdAsync(id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        if (post.UserId != userId)
        {
            throw new UserForbiddenException();
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        post.Update(title, content, utcNow);
        _postWriteRepository.Update(post);

        var integrationEvent = _instaConnectMapper.Map<UpdatedPostEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }

    public async Task DeleteAsync(
        string id,
        string userId,
        CancellationToken cancellationToken)
    {
        var post = await _postWriteRepository.GetByIdAsync(id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        if (post.UserId != userId)
        {
            throw new UserForbiddenException();
        }

        var integrationEvent = _instaConnectMapper.Map<DeletedPostEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }
}
