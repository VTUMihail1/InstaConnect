using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;
internal class PostService : IPostService
{
    private readonly IPostFactory _postFactory;
    private readonly IEventPublisher _eventPublisher;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;

    public PostService(
        IPostFactory postFactory,
        IEventPublisher eventPublisher,
        IPostRepository postRepository,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper)
    {
        _postFactory = postFactory;
        _eventPublisher = eventPublisher;
        _postRepository = postRepository;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
    }

    public async Task<PostCollection> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAllAsync(query, cancellationToken);

        return posts;
    }

    public async Task<Post> GetByIdAsync(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(query.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(query.Id);
        }

        return post!;
    }

    public async Task<Post> AddAsync(AddPostCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.CurrentUserId, cancellationToken);

        if (user.EqualsNull())
        {
            throw new UserNotFoundException(command.CurrentUserId);
        }

        var post = _postFactory.Create(command.CurrentUserId, command.Title, command.Content);
        _postRepository.Add(post);

        var integrationEvent = _applicationMapper.Map<PostAddedEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }

    public async Task<Post> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        if (post!.UserId.NotEqualsOrdinalIgnoreCase(command.CurrentUserId))
        {
            throw new PostForbiddenException(command.Id, command.CurrentUserId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        post.Update(command.Title, command.Content, utcNow);
        _postRepository.Update(post);

        var integrationEvent = _applicationMapper.Map<PostUpdatedEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }

    public async Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        if (post!.UserId.NotEqualsOrdinalIgnoreCase(command.CurrentUserId))
        {
            throw new PostForbiddenException(command.Id, command.CurrentUserId);
        }

        var integrationEvent = _applicationMapper.Map<PostDeletedEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);
    }
}
