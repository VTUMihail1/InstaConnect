namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollower;

internal class GetAllFollowsForFollowerQueryHandler : IQueryHandler<GetAllFollowsForFollowerQueryRequest, GetAllFollowsForFollowerQueryResponse>
{
    private readonly IApplicationMapper _mapper;
    private readonly IFollowQueryService _service;

    public GetAllFollowsForFollowerQueryHandler(
        IApplicationMapper mapper,
        IFollowQueryService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<GetAllFollowsForFollowerQueryResponse> Handle(
        GetAllFollowsForFollowerQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _mapper.Map<GetAllFollowsForFollowerQuery>(request);
        var serviceResponse = await _service.GetAllForFollowerAsync(serviceRequest, cancellationToken);

        var response = _mapper.Map<GetAllFollowsForFollowerQueryResponse>(serviceResponse);

        return response;
    }
}
