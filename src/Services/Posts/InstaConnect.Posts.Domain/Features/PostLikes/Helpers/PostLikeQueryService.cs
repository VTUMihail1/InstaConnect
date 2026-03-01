namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
internal class PostLikeQueryService : IPostLikeQueryService
{
    private readonly IPostQueryRepository _repository;
    private readonly IUserQueryRepository _userRepository;
    private readonly IPostLikeQueryRepository _likeRepository;
    private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
    private readonly IPostLikeIncludeBuilderFactory _likeIncludeBuilderFactory;
    private readonly IPostLikeCollectionResponseFactory _likeCollectionResponseFactory;

    public PostLikeQueryService(
        IPostQueryRepository repository,
        IUserQueryRepository userRepository,
        IPostLikeQueryRepository likeRepository,
        IPostIncludeBuilderFactory includeBuilderFactory,
        IPostLikeIncludeBuilderFactory likeIncludeBuilderFactory,
        IPostLikeCollectionResponseFactory likeCollectionResponseFactory)
    {
        _repository = repository;
        _userRepository = userRepository;
        _likeRepository = likeRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _likeIncludeBuilderFactory = likeIncludeBuilderFactory;
        _likeCollectionResponseFactory = likeCollectionResponseFactory;
    }

    public async Task<PostLikeCollectionResponse> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var post = await _repository.GetByIdAsync(query.Filter.Id, query.CurrentUser, include, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException(query.Filter.Id);
        }

        var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().Build();
        var postLikes = await _likeRepository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            likeInclude,
            cancellationToken);

        var totalCount = await _likeRepository.GetTotalCountAsync(query.Filter, likeInclude, cancellationToken);

        return _likeCollectionResponseFactory.CreateForPost(post, postLikes, totalCount, query.Pagination);
    }

    public async Task<PostLikeCollectionResponse> GetAllForUserAsync(GetAllPostLikesForUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(query.Filter.UserId);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var likeInclude = _likeIncludeBuilderFactory.Create().WithPost(include).Build();
        var postLikes = await _likeRepository.GetAllForUserAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            likeInclude,
            cancellationToken);

        var totalCount = await _likeRepository.GetTotalCountForUserAsync(query.Filter, likeInclude, cancellationToken);

        return _likeCollectionResponseFactory.CreateForUser(user, postLikes, totalCount, query.Pagination);
    }

    public async Task<PostLikeResponse> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken)
    {
        var postNotExists = !await _repository.ExistsByIdAsync(query.Id.Id, cancellationToken);

        if (postNotExists)
        {
            throw new PostNotFoundException(query.Id.Id);
        }

        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();
        var postLike = await _likeRepository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            likeInclude,
            cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException(query.Id);
        }

        return postLike;
    }
}
