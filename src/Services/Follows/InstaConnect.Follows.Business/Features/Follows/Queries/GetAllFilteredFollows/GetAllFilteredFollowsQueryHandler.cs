using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Follows.Data.Features.Follows.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFilteredFollows;

internal class GetAllFilteredFollowsQueryHandler : IQueryHandler<GetAllFilteredFollowsQuery, FollowPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IFollowReadRepository _followReadRepository;

    public GetAllFilteredFollowsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IFollowReadRepository followReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _followReadRepository = followReadRepository;
    }

    public async Task<FollowPaginationQueryViewModel> Handle(
        GetAllFilteredFollowsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredQuery = _instaConnectMapper.Map<FollowFilteredCollectionReadQuery>(request);

        var follows = await _followReadRepository.GetAllFilteredAsync(filteredQuery, cancellationToken);
        var response = _instaConnectMapper.Map<FollowPaginationQueryViewModel>(follows);

        return response;
    }
}
