﻿using AutoMapper;
using InstaConnect.Follows.Business.Models;
using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFilteredFollows
{
    public class GetAllFilteredFollowsQueryHandler : IQueryHandler<GetAllFilteredFollowsQuery, ICollection<FollowViewDTO>>
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

        public async Task<ICollection<FollowViewDTO>> Handle(GetAllFilteredFollowsQuery request, CancellationToken cancellationToken)
        {
            var followFilteredCollectionQuery = _mapper.Map<FollowFilteredCollectionQuery>(request);

            var follows = await _followRepository.GetAllFilteredAsync(followFilteredCollectionQuery, cancellationToken);
            var followViewDTOs = _mapper.Map<ICollection<FollowViewDTO>>(follows);

            return followViewDTOs;
        }
    }
}
