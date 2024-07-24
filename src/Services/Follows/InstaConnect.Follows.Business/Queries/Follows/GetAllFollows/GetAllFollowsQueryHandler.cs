using AutoMapper;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;

public class GetAllFollowsQueryHandler : IQueryHandler<GetAllFollowsQuery, ICollection<FollowQueryViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IFollowReadRepository _followRepository;

    public GetAllFollowsQueryHandler(
        IMapper mapper,
        IFollowReadRepository followRepository)
    {
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<ICollection<FollowQueryViewModel>> Handle(GetAllFollowsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionReadQuery>(request);

        var follows = await _followRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<FollowQueryViewModel>>(follows);

        return response;
    }
}
