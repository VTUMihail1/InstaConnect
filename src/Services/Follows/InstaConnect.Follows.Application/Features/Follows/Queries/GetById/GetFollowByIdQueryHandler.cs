namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

internal class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQueryRequest, GetFollowByIdQueryResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IFollowIncludeQueryBuilderFactory _followIncludeQueryBuilderFactory;

    public GetFollowByIdQueryHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper,
        IFollowIncludeQueryBuilderFactory followIncludeQueryBuilderFactory)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
        _followIncludeQueryBuilderFactory = followIncludeQueryBuilderFactory;
    }

    public async Task<GetFollowByIdQueryResponse> Handle(
        GetFollowByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _followIncludeQueryBuilderFactory.Create().WithFollower().WithFollowing().Build();
        var serviceRequest = _applicationMapper.Map<GetFollowByIdQuery>(request).AddInclude(include);
        var follow = await _followService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetFollowByIdQueryResponse>(follow);

        return response;
    }
}
