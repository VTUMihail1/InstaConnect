using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

internal class GetAllFollowsByFollowingQueryHandler : IQueryHandler<GetAllFollowsByFollowingQueryRequest, GetAllFollowsByFollowingQueryResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllFollowsByFollowingQueryHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllFollowsByFollowingQueryResponse> Handle(
        GetAllFollowsByFollowingQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllFollowsByFollowingQuery>(request);
        var collection = await _followService.GetAllByFollowingAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllFollowsByFollowingQueryResponse>(collection);

        return response;
    }
}
