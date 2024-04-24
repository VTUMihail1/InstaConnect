﻿using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes
{
    public class GetAllFilteredPostLikeQueryHandler : IQueryHandler<GetAllFilteredPostLikesQuery, ICollection<PostLikeViewDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostLikeRepository _postLikeRepository;

        public GetAllFilteredPostLikeQueryHandler(
            IMapper mapper,
            IPostLikeRepository postLikeRepository)
        {
            _mapper = mapper;
            _postLikeRepository = postLikeRepository;
        }

        public async Task<ICollection<PostLikeViewDTO>> Handle(GetAllFilteredPostLikesQuery request, CancellationToken cancellationToken)
        {
            var postLikeFilteredCollectionQuery = _mapper.Map<PostLikeFilteredCollectionQuery>(request);

            var postLikes = await _postLikeRepository.GetAllFilteredAsync(postLikeFilteredCollectionQuery, cancellationToken);
            var postLikeViewDTOs = _mapper.Map<ICollection<PostLikeViewDTO>>(postLikes);

            return postLikeViewDTOs;
        }
    }
}