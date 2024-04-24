using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes
{
    public class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQuery, ICollection<PostCommentLikeViewDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentLikeRepository _postCommentLikeRepository;

        public GetAllPostCommentLikesQueryHandler(
            IMapper mapper,
            IPostCommentLikeRepository postCommentLikeRepository)
        {
            _mapper = mapper;
            _postCommentLikeRepository = postCommentLikeRepository;
        }

        public async Task<ICollection<PostCommentLikeViewDTO>> Handle(GetAllPostCommentLikesQuery request, CancellationToken cancellationToken)
        {
            var collectionQuery = _mapper.Map<CollectionQuery>(request);

            var postCommentLikes = await _postCommentLikeRepository.GetAllAsync(collectionQuery, cancellationToken);
            var postCommentLikeViewDTOs = _mapper.Map<ICollection<PostCommentLikeViewDTO>>(postCommentLikes);

            return postCommentLikeViewDTOs;
        }
    }
}
