using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;

internal class GetAllFilteredPostsQueryHandler : IQueryHandler<GetAllFilteredPostsQuery, ICollection<PostViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public GetAllFilteredPostsQueryHandler(
        IMapper mapper,
        IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<ICollection<PostViewModel>> Handle(GetAllFilteredPostsQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostFilteredCollectionQuery>(request);

        var posts = await _postRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostViewModel>>(posts);

        return response;
    }
}
