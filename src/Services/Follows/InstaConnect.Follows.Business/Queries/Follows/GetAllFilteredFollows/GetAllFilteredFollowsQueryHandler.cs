using AutoMapper;
using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;

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
