using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById
{
    public class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetPostByIdQueryHandler(
            IMapper mapper,
            IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<PostViewDTO> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

            if (post == null)
            {
                throw new PostNotFoundException();
            }

            var postViewDTO = _mapper.Map<PostViewDTO>(post);

            return postViewDTO;
        }
    }
}
