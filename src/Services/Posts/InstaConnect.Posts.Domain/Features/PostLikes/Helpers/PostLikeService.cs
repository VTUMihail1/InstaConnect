using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.PostLikeLikes.Domain.Features.PostLikeLikes.Abstractions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;
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
        var post = await _postRepository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var postLikes = await _postLikeRepository.GetAllAsync(query, cancellationToken);

        return postLikes;
    }

    public async Task<PostLike> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(query.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(query.Id);
        }

        var postLike = await _postLikeRepository.GetByIdAsync(query.Id, query.LikeId, cancellationToken);

        if (postLike.EqualsNull())
        {
            throw new PostLikeNotFoundException(query.Id, query.LikeId);
        }

        return postLike!;
    }

    public async Task<PostLike> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var user = await _userRepository.GetByIdAsync(command.CurrentUserId, cancellationToken);

        if (user.EqualsNull())
        {
            throw new UserNotFoundException(command.CurrentUserId);
        }

        var existingPostLike = await _postLikeRepository.GetByIdAndUserIdAsync(command.Id, command.CurrentUserId, cancellationToken);

        if (existingPostLike.EqualsNull())
        {
            throw new PostLikeAlreadyExistsException(command.Id, command.CurrentUserId);
        }

        var postLike = _postLikeFactory.Create(command.Id, command.CurrentUserId);
        _postLikeRepository.Add(postLike);

        var integrationEvent = _applicationMapper.Map<PostLikeAddedEvent>(postLike);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return postLike;
    }

    public async Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (post.EqualsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var postLike = await _postLikeRepository.GetByIdAsync(command.Id, command.LikeId, cancellationToken);

        if (postLike.EqualsNull())
        {
            throw new PostLikeNotFoundException(command.Id, command.LikeId);
        }

        if (postLike!.UserId.NotEqualsOrdinalIgnoreCase(command.CurrentUserId))
        {
            throw new PostLikeForbiddenException(command.Id, command.LikeId, command.CurrentUserId);
        }

        _postLikeRepository.Delete(postLike);

        var integrationEvent = _applicationMapper.Map<PostLikeDeletedEvent>(postLike);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);
    }
}
