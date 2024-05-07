using AutoMapper;
using InstaConnect.Follows.Business.Models;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;

internal class GetAllFollowsQueryHandler : IQueryHandler<GetAllFollowsQuery, ICollection<FollowViewDTO>>
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

    public async Task<ICollection<FollowViewDTO>> Handle(GetAllFollowsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);

        var follows = await _followRepository.GetAllAsync(collectionQuery, cancellationToken);
        var followViewDTOs = _mapper.Map<ICollection<FollowViewDTO>>(follows);

        return followViewDTOs;
    }
}
