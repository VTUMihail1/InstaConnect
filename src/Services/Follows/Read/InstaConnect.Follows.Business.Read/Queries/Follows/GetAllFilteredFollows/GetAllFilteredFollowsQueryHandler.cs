using AutoMapper;
using InstaConnect.Follows.Business.Read.Models;
using InstaConnect.Follows.Data.Read.Abstractions;
using InstaConnect.Follows.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;

internal class GetAllFilteredFollowsQueryHandler : IQueryHandler<GetAllFilteredFollowsQuery, ICollection<FollowViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;

    public GetAllFilteredFollowsQueryHandler(
        IMapper mapper,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<ICollection<FollowViewModel>> Handle(GetAllFilteredFollowsQuery request, CancellationToken cancellationToken)
    {
        var filteredQuery = _mapper.Map<FollowFilteredCollectionQuery>(request);

        var follows = await _followRepository.GetAllFilteredAsync(filteredQuery, cancellationToken);
        var response = _mapper.Map<ICollection<FollowViewModel>>(follows);

        return response;
    }
}
