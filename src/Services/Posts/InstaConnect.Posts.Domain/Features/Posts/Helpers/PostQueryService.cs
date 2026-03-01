namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostQueryService : IPostQueryService
{
    private readonly IPostQueryRepository _repository;
    private readonly IUserQueryRepository _userRepository;
    private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
    private readonly IPostCollectionResponseFactory _collectionResponseFactory;

    public PostQueryService(
        IPostQueryRepository repository,
        IUserQueryRepository userRepository,
        IPostIncludeBuilderFactory includeBuilderFactory,
        IPostCollectionResponseFactory collectionResponseFactory)
    {
        _repository = repository;
        _userRepository = userRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _collectionResponseFactory = collectionResponseFactory;
    }

    public async Task<PostCollectionResponse> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var posts = await _repository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            include,
            cancellationToken);

        var totalCount = await _repository.GetTotalCountAsync(query.Filter, include, cancellationToken);

        return _collectionResponseFactory.Create(posts, totalCount, query.Pagination);
    }

    public async Task<PostCollectionResponse> GetAllForUserAsync(GetAllPostsForUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(query.Filter.UserId);
        }

        var include = _includeBuilderFactory.Create().WithPostLikes().Build();
        var posts = await _repository.GetAllForUserAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            include,
            cancellationToken);

        var totalCount = await _repository.GetTotalCountForUserAsync(query.Filter, include, cancellationToken);

        return _collectionResponseFactory.CreateForUser(user, posts, totalCount, query.Pagination);
    }

    public async Task<PostResponse> GetByIdAsync(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var post = await _repository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            include,
            cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException(query.Id);
        }

        return post;
    }
}
