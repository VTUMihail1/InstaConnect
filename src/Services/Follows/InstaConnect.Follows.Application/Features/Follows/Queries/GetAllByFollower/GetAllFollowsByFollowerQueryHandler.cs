using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

internal class GetAllFollowsByFollowerQueryHandler : IQueryHandler<GetAllFollowsByFollowerQueryRequest, GetAllFollowsByFollowerQueryResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllFollowsByFollowerQueryHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllFollowsByFollowerQueryResponse> Handle(
        GetAllFollowsByFollowerQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllFollowsByFollowerQuery>(request);
        var collection = await _followService.GetAllByFollowerAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllFollowsByFollowerQueryResponse>(collection);

        return response;
    }
}
