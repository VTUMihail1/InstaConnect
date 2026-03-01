namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

internal class PostCommentQueryService : IPostCommentQueryService
{
    private readonly IPostQueryRepository _repository;
    private readonly IUserQueryRepository _userRepository;
    private readonly IPostCommentQueryRepository _commentRepository;
    private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
    private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
    private readonly IPostCommentCollectionResponseFactory _commentCollectionResponseFactory;

    public PostCommentQueryService(
        IPostQueryRepository repository,
        IUserQueryRepository userRepository,
        IPostCommentQueryRepository commentRepository,
        IPostIncludeBuilderFactory includeBuilderFactory,
        IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
        IPostCommentCollectionResponseFactory commentCollectionResponseFactory)
    {
        _repository = repository;
        _userRepository = userRepository;
        _commentRepository = commentRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _commentIncludeBuilderFactory = commentIncludeBuilderFactory;
        _commentCollectionResponseFactory = commentCollectionResponseFactory;
    }

    public async Task<PostCommentCollectionResponse> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var post = await _repository.GetByIdAsync(query.Filter.Id, query.CurrentUser, include, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().Build();
        var postComments = await _commentRepository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            commentInclude,
            cancellationToken);

        var totalCount = await _commentRepository.GetTotalCountAsync(query.Filter, commentInclude, cancellationToken);

        return _commentCollectionResponseFactory.CreateForPost(post, postComments, totalCount, query.Pagination);
    }

    public async Task<PostCommentCollectionResponse> GetAllForUserAsync(GetAllPostCommentsForUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(query.Filter.UserId);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithPost(include).WithPostCommentLikes().Build();
        var postComments = await _commentRepository.GetAllForUserAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            commentInclude,
            cancellationToken);

        var totalCount = await _commentRepository.GetTotalCountForUserAsync(query.Filter, commentInclude, cancellationToken);

        return _commentCollectionResponseFactory.CreateForUser(user, postComments, totalCount, query.Pagination);
    }

    public async Task<PostCommentResponse> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken)
    {
        var postNotExists = !await _repository.ExistsByIdAsync(query.Id.Id, cancellationToken);

        if (postNotExists)
        {
            throw new PostNotFoundException(query.Id.Id);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPost(include).Build();
        var postComment = await _commentRepository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            commentInclude,
            cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException(query.Id);
        }

        return postComment;
    }
}
