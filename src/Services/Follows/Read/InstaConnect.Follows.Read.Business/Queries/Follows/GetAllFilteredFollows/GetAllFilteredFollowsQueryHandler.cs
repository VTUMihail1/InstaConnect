﻿using AutoMapper;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Read.Data.Abstractions;
using InstaConnect.Follows.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;

public class GetAllFilteredFollowsQueryHandler : IQueryHandler<GetAllFilteredFollowsQuery, ICollection<FollowViewModel>>
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