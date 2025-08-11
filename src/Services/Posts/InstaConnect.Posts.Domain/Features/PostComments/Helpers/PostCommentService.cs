using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Exceptions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Helpers;
internal class PostCommentService : IPostCommentService
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentFactory _postCommentFactory;
    private readonly IPostCommentRepository _postCommentRepository;

    public PostCommentService(
        IEventPublisher eventPublisher,
        IPostRepository postRepository,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IPostCommentFactory postCommentFactory,
        IPostCommentRepository postCommentRepository)
    {
        _eventPublisher = eventPublisher;
        _postRepository = postRepository;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _postCommentFactory = postCommentFactory;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<PostCommentCollection> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var existingPostCommentCollection = await _postCommentRepository.GetAllAsync(query, cancellationToken);

        return existingPostCommentCollection;
    }

    public async Task<PostComment> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(query.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(query.Id, query.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(query.Id, query.CommentId);
        }

        return existingPostComment!;
    }

    public async Task<PostComment> AddAsync(AddPostCommentCommand command, CancellationToken cancellationToken)
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

        var postComment = _postCommentFactory.Create(command.Id, command.UserId, command.Content);
        _postCommentRepository.Add(postComment);

        var eventRequest = _applicationMapper.Map<PostCommentAddedEventRequest>(postComment);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postComment;
    }

    public async Task<PostComment> UpdateAsync(UpdatePostCommentCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(command.Id, command.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id, command.CommentId);
        }

        if (existingPostComment!.UserId.NotEqualsOrdinalIgnoreCase(command.UserId))
        {
            throw new PostCommentForbiddenException(command.Id, command.CommentId, command.UserId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingPostComment.Update(command.Content, utcNow);
        _postCommentRepository.Update(existingPostComment);

        var eventRequest = _applicationMapper.Map<PostCommentUpdatedEventRequest>(existingPostComment);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return existingPostComment;
    }

    public async Task DeleteAsync(DeletePostCommentCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id);
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(command.Id, command.CommentId, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id, command.CommentId);
        }

        if (existingPostComment!.UserId.NotEqualsOrdinalIgnoreCase(command.UserId))
        {
            throw new PostCommentForbiddenException(command.Id, command.CommentId, command.UserId);
        }

        _postCommentRepository.Delete(existingPostComment);

        var eventRequest = _applicationMapper.Map<PostCommentDeletedEventRequest>(existingPostComment);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
