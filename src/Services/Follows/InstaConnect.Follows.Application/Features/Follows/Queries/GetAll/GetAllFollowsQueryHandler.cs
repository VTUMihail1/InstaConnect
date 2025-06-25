using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

internal class GetAllFollowsQueryHandler : IQueryHandler<GetAllFollowsQuery, FollowPaginationQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IFollowReadRepository _followReadRepository;

    public GetAllFollowsQueryHandler(
        IApplicationMapper applicationMapper,
        IFollowReadRepository followReadRepository)
    {
        _applicationMapper = applicationMapper;
        _followReadRepository = followReadRepository;
    }

    public async Task<FollowPaginationQueryViewModel> Handle(
        GetAllFollowsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredQuery = _applicationMapper.Map<FollowCollectionReadQuery>(request);

        var follows = await _followReadRepository.GetAllAsync(filteredQuery, cancellationToken);
        var response = _applicationMapper.Map<FollowPaginationQueryViewModel>(follows);

        return response;
    }
}
