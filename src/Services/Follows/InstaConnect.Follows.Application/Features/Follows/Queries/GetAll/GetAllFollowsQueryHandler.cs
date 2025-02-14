using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

internal class GetAllFollowsQueryHandler : IQueryHandler<GetAllFollowsQuery, FollowPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IFollowReadRepository _followReadRepository;

    public GetAllFollowsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IFollowReadRepository followReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _followReadRepository = followReadRepository;
    }

    public async Task<FollowPaginationQueryViewModel> Handle(
        GetAllFollowsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredQuery = _instaConnectMapper.Map<FollowCollectionReadQuery>(request);

        var follows = await _followReadRepository.GetAllAsync(filteredQuery, cancellationToken);
        var response = _instaConnectMapper.Map<FollowPaginationQueryViewModel>(follows);

        return response;
    }
}
