namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

internal class FollowQueryService : IFollowQueryService
{
    private readonly IFollowQueryRepository _repository;
    private readonly IUserQueryRepository _userRepository;
    private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;
    private readonly IFollowCollectionResponseFactory _collectionResponseFactory;

    public FollowQueryService(
        IFollowQueryRepository repository,
        IUserQueryRepository userRepository,
        IFollowIncludeBuilderFactory includeBuilderFactory,
        IFollowCollectionResponseFactory collectionResponseFactory)
    {
        _repository = repository;
        _userRepository = userRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _collectionResponseFactory = collectionResponseFactory;
    }

    public async Task<FollowCollectionResponse> GetAllAsync(GetAllFollowsQuery query, CancellationToken cancellationToken)
    {
        var follower = await _userRepository.GetByIdAsync(query.Filter.FollowerId, query.CurrentUser, cancellationToken);

        if (follower == null)
        {
            throw new UserNotFoundException(query.Filter.FollowerId);
        }

        var include = _includeBuilderFactory.Create().WithFollowing().Build();
        var follows = await _repository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            include,
            cancellationToken);

        var totalCount = await _repository.GetTotalCountAsync(query.Filter, cancellationToken);

        return _collectionResponseFactory.Create(follower, follows, totalCount, query.Pagination);
    }

    public async Task<FollowCollectionResponse> GetAllForFollowingAsync(GetAllFollowsForFollowingQuery query, CancellationToken cancellationToken)
    {
        var following = await _userRepository.GetByIdAsync(query.Filter.FollowingId, query.CurrentUser, cancellationToken);

        if (following == null)
        {
            throw new UserNotFoundException(query.Filter.FollowingId);
        }

        var include = _includeBuilderFactory.Create().WithFollower().Build();
        var follows = await _repository.GetAllForFollowingAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            include,
            cancellationToken);

        var totalCount = await _repository.GetTotalCountForFollowingAsync(query.Filter, cancellationToken);

        return _collectionResponseFactory.CreateForFollowing(following, follows, totalCount, query.Pagination);
    }

    public async Task<FollowResponse> GetByIdAsync(GetFollowByIdQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithFollower().WithFollowing().Build();
        var follow = await _repository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            include,
            cancellationToken);

        if (follow == null)
        {
            throw new FollowNotFoundException(query.Id);
        }

        return follow;
    }
}
