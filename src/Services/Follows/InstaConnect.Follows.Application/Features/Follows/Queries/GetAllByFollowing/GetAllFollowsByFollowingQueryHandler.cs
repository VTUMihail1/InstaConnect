namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

internal class GetAllFollowsByFollowingQueryHandler : IQueryHandler<GetAllFollowsByFollowingQueryRequest, GetAllFollowsByFollowingQueryResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IFollowIncludeQueryBuilderFactory _followIncludeQueryBuilderFactory;

    public GetAllFollowsByFollowingQueryHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper,
        IFollowIncludeQueryBuilderFactory followIncludeQueryBuilderFactory)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
        _followIncludeQueryBuilderFactory = followIncludeQueryBuilderFactory;
    }

    public async Task<GetAllFollowsByFollowingQueryResponse> Handle(
        GetAllFollowsByFollowingQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _followIncludeQueryBuilderFactory.Create().WithFollower().WithFollowing().Build();
        var serviceRequest = _applicationMapper.Map<GetAllFollowsByFollowingQuery>(request).AddInclude(include);
        var collection = await _followService.GetAllByFollowingAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllFollowsByFollowingQueryResponse>(collection);

        return response;
    }
}
