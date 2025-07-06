using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
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

    public async Task<PostCollection> GetAllAsync(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAllAsync(request, cancellationToken);

        return posts;
    }

    public async Task<Post> GetByIdAsync(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException(request.Id);
        }

        return post;
    }

    public async Task<Post> AddAsync(AddPostRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.CurrentUserId);
        }

        var post = _postFactory.Create(request.CurrentUserId, request.Title, request.Content);
        _postRepository.Add(post);

        var integrationEvent = _applicationMapper.Map<AddedPostEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }

    public async Task<Post> UpdateAsync(UpdatePostRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException(request.Id);
        }

        if (post.UserId != request.CurrentUserId)
        {
            throw new PostForbiddenException(request.Id, request.CurrentUserId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        post.Update(request.Title, request.Content, utcNow);
        _postRepository.Update(post);

        var integrationEvent = _applicationMapper.Map<UpdatedPostEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return post;
    }

    public async Task DeleteAsync(DeletePostRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException(request.Id);
        }

        if (post.UserId != request.CurrentUserId)
        {
            throw new PostForbiddenException(request.Id, request.CurrentUserId);
        }

        var integrationEvent = _applicationMapper.Map<DeletedPostEvent>(post);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);
    }
}
