using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.Common.Helpers;
using InstaConnect.PostLikeLikes.Domain.Features.PostLikeLikes.Abstractions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.PostLikes.Domain.Features.Users.Abstractions;
using InstaConnect.PostLikes.Domain.Features.Users.Exceptions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;
internal class PostLikeService : IPostLikeService
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IPostLikeFactory _postLikeFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostLikeRepository _postLikeRepository;

    public PostLikeService(
        IEventPublisher eventPublisher, 
        IUserRepository userRepository, 
        IPostLikeFactory postLikeFactory, 
        IApplicationMapper applicationMapper, 
        IPostLikeRepository postLikeRepository)
    {
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _postLikeFactory = postLikeFactory;
        _applicationMapper = applicationMapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken)
    {
        var postLikes = await _postLikeRepository.GetAllAsync(query, cancellationToken);

        return postLikes;
    }

    public async Task<PostLike> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeRepository.GetByIdAsync(query.Id, query.PostId, cancellationToken);

        if (postLike.EqualsNull())
        {
            throw new PostLikeNotFoundException(query.Id, query.PostId);
        }

        return postLike!;
    }

    public async Task<PostLike> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.CurrentUserId, cancellationToken);

        if (user.EqualsNull())
        {
            throw new UserNotFoundException(command.CurrentUserId);
        }

        var postLike = _postLikeFactory.Create(command.CurrentUserId, command.PostId);
        _postLikeRepository.Add(postLike);

        var integrationEvent = _applicationMapper.Map<PostLikeAddedEvent>(postLike);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return postLike;
    }

    public async Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeRepository.GetByIdAsync(command.Id, command.PostId, cancellationToken);

        if (postLike.EqualsNull())
        {
            throw new PostLikeNotFoundException(command.Id, command.PostId);
        }

        if (postLike!.UserId.NotEqualsOrdinalIgnoreCase(command.CurrentUserId))
        {
            throw new PostLikeForbiddenException(command.Id, command.PostId, command.CurrentUserId);
        }

        var integrationEvent = _applicationMapper.Map<PostLikeDeletedEvent>(postLike);
        await _eventPublisher.PublishAsync(integrationEvent, cancellationToken);
    }
}
