using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetAllFilteredPosts;

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
