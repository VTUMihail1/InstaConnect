using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, ICollection<PostViewDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetAllPostsQueryHandler(
            IMapper mapper,
            IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<ICollection<PostViewDTO>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var collectionQuery = _mapper.Map<CollectionQuery>(request);

            var posts = await _postRepository.GetAllAsync(collectionQuery, cancellationToken);
            var postViewDTOs = _mapper.Map<ICollection<PostViewDTO>>(posts);

            return postViewDTOs;
        }
    }
}
