using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById
{
    public class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostLikeRepository _postLikeRepository;

        public GetPostLikeByIdQueryHandler(
            IMapper mapper,
            IPostLikeRepository postLikeRepository)
        {
            _mapper = mapper;
            _postLikeRepository = postLikeRepository;
        }

        public async Task<PostLikeViewDTO> Handle(GetPostLikeByIdQuery request, CancellationToken cancellationToken)
        {
            var postLike = await _postLikeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (postLike == null)
            {
                throw new PostLikeNotFoundException();
            }

            var postLikeViewDTO = _mapper.Map<PostLikeViewDTO>(postLike);

            return postLikeViewDTO;
        }
    }
}
