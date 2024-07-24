using AutoMapper;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;

public class GetAllFilteredFollowsQueryHandler : IQueryHandler<GetAllFilteredFollowsQuery, ICollection<FollowQueryViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IFollowReadRepository _followRepository;

    public GetAllFilteredFollowsQueryHandler(
        IMapper mapper,
        IFollowReadRepository followRepository)
    {
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<ICollection<FollowQueryViewModel>> Handle(GetAllFilteredFollowsQuery request, CancellationToken cancellationToken)
    {
        var filteredQuery = _mapper.Map<FollowFilteredCollectionReadQuery>(request);

        var follows = await _followRepository.GetAllFilteredAsync(filteredQuery, cancellationToken);
        var response = _mapper.Map<ICollection<FollowQueryViewModel>>(follows);

        return response;
    }
}
