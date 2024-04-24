using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById
{
    public class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQuery, PostCommentViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;

        public GetPostCommentByIdQueryHandler(
            IMapper mapper,
            IPostCommentRepository postCommentRepository)
        {
            _mapper = mapper;
            _postCommentRepository = postCommentRepository;
        }

        public async Task<PostCommentViewDTO> Handle(GetPostCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var postComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

            if (postComment == null)
            {
                throw new PostCommentNotFoundException();
            }

            var postCommentViewDTO = _mapper.Map<PostCommentViewDTO>(postComment);

            return postCommentViewDTO;
        }
    }
}
