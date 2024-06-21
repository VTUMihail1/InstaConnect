using AutoMapper;
using InstaConnect.Follows.Business.Models;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;

internal class GetAllFollowsQueryHandler : IQueryHandler<GetAllFollowsQuery, ICollection<FollowViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;

    public GetAllFollowsQueryHandler(
        IMapper mapper,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<ICollection<FollowViewModel>> Handle(GetAllFollowsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);

        var follows = await _followRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<FollowViewModel>>(follows);

        return response;
    }
}
