namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
internal class PostCommentLikeQueryService : IPostCommentLikeQueryService
{
    private readonly IPostQueryRepository _repository;
    private readonly IUserQueryRepository _userRepository;
    private readonly IPostCommentQueryRepository _commentRepository;
    private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
    private readonly IPostCommentLikeQueryRepository _commentLikeRepository;
    private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
    private readonly IPostCommentLikeIncludeBuilderFactory _commentLikeIncludeBuilderFactory;
    private readonly IPostCommentLikeCollectionResponseFactory _commentLikeCollectionResponseFactory;

    public PostCommentLikeQueryService(
        IPostQueryRepository repository,
        IUserQueryRepository userRepository,
        IPostCommentQueryRepository commentRepository,
        IPostIncludeBuilderFactory includeBuilderFactory,
        IPostCommentLikeQueryRepository commentLikeRepository,
        IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
        IPostCommentLikeIncludeBuilderFactory commentLikeIncludeBuilderFactory,
        IPostCommentLikeCollectionResponseFactory commentLikeCollectionResponseFactory)
    {
        _repository = repository;
        _userRepository = userRepository;
        _commentRepository = commentRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _commentLikeRepository = commentLikeRepository;
        _commentIncludeBuilderFactory = commentIncludeBuilderFactory;
        _commentLikeIncludeBuilderFactory = commentLikeIncludeBuilderFactory;
        _commentLikeCollectionResponseFactory = commentLikeCollectionResponseFactory;
    }

    public async Task<PostCommentLikeCollectionResponse> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken)
    {
        var postNotExists = !await _repository.ExistsByIdAsync(query.Filter.CommentId.Id, cancellationToken);

        if (postNotExists)
        {
            throw new PostNotFoundException(query.Filter.CommentId.Id);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().Build();
        var postComment = await _commentRepository.GetByIdAsync(query.Filter.CommentId, query.CurrentUser, commentInclude, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException(query.Filter.CommentId);
        }

        var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().Build();
        var postCommentLikes = await _commentLikeRepository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            commentLikeInclude,
            cancellationToken);

        var totalCount = await _commentLikeRepository.GetTotalCountAsync(query.Filter, commentLikeInclude, cancellationToken);

        return _commentLikeCollectionResponseFactory.Create(postComment, postCommentLikes, totalCount, query.Pagination);
    }

    public async Task<PostCommentLikeCollectionResponse> GetAllForUserAsync(GetAllPostCommentLikesForUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(query.Filter.UserId);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().Build();
        var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithPostComment(commentInclude).Build();
        var postCommentLikes = await _commentLikeRepository.GetAllForUserAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            commentLikeInclude,
            cancellationToken);

        var totalCount = await _commentLikeRepository.GetTotalCountForUserAsync(query.Filter, commentLikeInclude, cancellationToken);

        return _commentLikeCollectionResponseFactory.CreateForUser(user, postCommentLikes, totalCount, query.Pagination);
    }

    public async Task<PostCommentLikeResponse> GetByIdAsync(GetPostCommentLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var postNotExists = !await _repository.ExistsByIdAsync(query.Id.CommentId.Id, cancellationToken);

        if (postNotExists)
        {
            throw new PostNotFoundException(query.Id.CommentId.Id);
        }

        var postCommentNotExists = !await _commentRepository.ExistsByIdAsync(query.Id.CommentId, cancellationToken);

        if (postCommentNotExists)
        {
            throw new PostCommentNotFoundException(query.Id.CommentId);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().Build();
        var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(commentInclude).Build();
        var postCommentLike = await _commentLikeRepository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            commentLikeInclude,
            cancellationToken);

        if (postCommentLike == null)
        {
            throw new PostCommentLikeNotFoundException(query.Id);
        }

        return postCommentLike;
    }
}
