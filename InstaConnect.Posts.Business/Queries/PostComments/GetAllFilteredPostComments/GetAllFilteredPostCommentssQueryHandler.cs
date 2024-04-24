using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Data.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts
{
    public class GetAllFilteredPostCommentssQueryHandler : IQueryHandler<GetAllFilteredPostCommentsQuery, ICollection<PostCommentViewDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;

        public GetAllFilteredPostCommentssQueryHandler(
            IMapper mapper,
            IPostCommentRepository postCommentRepository)
        {
            _mapper = mapper;
            _postCommentRepository = postCommentRepository;
        }

        public async Task<ICollection<PostCommentViewDTO>> Handle(GetAllFilteredPostCommentsQuery request, CancellationToken cancellationToken)
        {
            var postCommentFilteredCollectionQuery = _mapper.Map<PostCommentFilteredCollectionQuery>(request);

            var postComments = await _postCommentRepository.GetAllFilteredAsync(postCommentFilteredCollectionQuery, cancellationToken);
            var postCommentViewDTOs = _mapper.Map<ICollection<PostCommentViewDTO>>(postComments);

            return postCommentViewDTOs;
        }
    }
}
