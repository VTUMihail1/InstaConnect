namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

internal class GetAllFollowsByFollowerQueryHandler : IQueryHandler<GetAllFollowsByFollowerQueryRequest, GetAllFollowsByFollowerQueryResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IFollowIncludeQueryBuilderFactory _followIncludeQueryBuilderFactory;

    public GetAllFollowsByFollowerQueryHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper,
        IFollowIncludeQueryBuilderFactory followIncludeQueryBuilderFactory)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
        _followIncludeQueryBuilderFactory = followIncludeQueryBuilderFactory;
    }

    public async Task<GetAllFollowsByFollowerQueryResponse> Handle(
        GetAllFollowsByFollowerQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _followIncludeQueryBuilderFactory.Create().WithFollower().WithFollowing().Build();
        var serviceRequest = _applicationMapper.Map<GetAllFollowsByFollowerQuery>(request).AddInclude(include);
        var collection = await _followService.GetAllByFollowerAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllFollowsByFollowerQueryResponse>(collection);

        return response;
    }
}
