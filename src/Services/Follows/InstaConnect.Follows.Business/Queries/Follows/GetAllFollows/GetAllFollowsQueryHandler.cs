using AutoMapper;
using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;

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
        var collectionQuery = _instaConnectMapper.Map<FollowCollectionReadQuery>(request);

        var follows = await _followReadRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<FollowPaginationQueryViewModel>(follows);

        return response;
    }
}
