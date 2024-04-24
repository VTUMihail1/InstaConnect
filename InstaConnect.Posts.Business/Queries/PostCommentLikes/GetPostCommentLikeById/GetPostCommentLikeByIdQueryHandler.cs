using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Exceptions.PostCommentLike;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById
{
    public class GetPostCommentLikeByIdQueryHandler : IQueryHandler<GetPostCommentLikeByIdQuery, PostCommentLikeViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentLikeRepository _postCommentLikeRepository;

        public GetPostCommentLikeByIdQueryHandler(
            IMapper mapper,
            IPostCommentLikeRepository postCommentLikeRepository)
        {
            _mapper = mapper;
            _postCommentLikeRepository = postCommentLikeRepository;
        }

        public async Task<PostCommentLikeViewDTO> Handle(GetPostCommentLikeByIdQuery request, CancellationToken cancellationToken)
        {
            var postCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (postCommentLike == null)
            {
                throw new PostCommentLikeNotFoundException();
            }

            var postCommentLikeViewDTO = _mapper.Map<PostCommentLikeViewDTO>(postCommentLike);

            return postCommentLikeViewDTO;
        }
    }
}
