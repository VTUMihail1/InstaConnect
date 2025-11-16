using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;
internal class PostCommentService : IPostCommentService
{
    private readonly IPostRepository _repository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IPostCommentFactory _commentFactory;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentRepository _commentRepository;

    public PostCommentService(
        IPostRepository repository,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IPostCommentFactory commentFactory,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IPostCommentRepository commentRepository)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _commentFactory = commentFactory;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _commentRepository = commentRepository;
    }

    public async Task<PostCommentCollection> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var existingPostCommentCollection = await _commentRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingPostCommentCollection;
    }

    public async Task<PostComment> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(query.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(query.Id.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(query.Id);
        }

        return existingPostComment!;
    }

    public async Task<PostComment> AddAsync(AddPostCommentCommand command, CancellationToken cancellationToken)
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

        var postComment = _commentFactory.Create(command.Id, command.UserId, command.Content);
        await _commentRepository.AddAsync(postComment, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentAddedEventRequest>(postComment);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return postComment;
    }

    public async Task<PostComment> UpdateAsync(UpdatePostCommentCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id);
        }

        if (existingPostComment!.IsNotOwnedByUser(command.UserId))
        {
            throw new PostCommentForbiddenException(command.Id, command.UserId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingPostComment.Update(command.Content, utcNow);
        await _commentRepository.UpdateAsync(existingPostComment, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentUpdatedEventRequest>(existingPostComment);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return existingPostComment;
    }

    public async Task DeleteAsync(DeletePostCommentCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await _repository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingPost.IsNull())
        {
            throw new PostNotFoundException(command.Id.Id);
        }

        var existingPostComment = await _commentRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingPostComment.IsNull())
        {
            throw new PostCommentNotFoundException(command.Id);
        }

        if (existingPostComment!.IsNotOwnedByUser(command.UserId))
        {
            throw new PostCommentForbiddenException(command.Id, command.UserId);
        }

        await _commentRepository.DeleteAsync(existingPostComment, cancellationToken);

        var eventRequest = _applicationMapper.Map<PostCommentDeletedEventRequest>(existingPostComment);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
