using AutoMapper;
using InstaConnect.Posts.Data.Models.Filters.Posts;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetAllFilteredPosts;

internal class GetAllFilteredPostsQueryHandler : IQueryHandler<GetAllFilteredPostsQuery, ICollection<PostQueryViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostReadRepository _postRepository;

    public GetAllFilteredPostsQueryHandler(
        IMapper mapper,
        IPostReadRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<ICollection<PostQueryViewModel>> Handle(GetAllFilteredPostsQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostFilteredCollectionReadQuery>(request);

        var posts = await _postRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostQueryViewModel>>(posts);

        return response;
    }
}
