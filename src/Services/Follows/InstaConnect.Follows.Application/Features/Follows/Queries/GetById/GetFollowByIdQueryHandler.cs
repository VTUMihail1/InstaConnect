using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

internal class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQueryRequest, GetFollowByIdQueryResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;

    public GetFollowByIdQueryHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetFollowByIdQueryResponse> Handle(
        GetFollowByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetFollowByIdQuery>(request);
        var follow = await _followService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetFollowByIdQueryResponse>(follow);

        return response;
    }
}
