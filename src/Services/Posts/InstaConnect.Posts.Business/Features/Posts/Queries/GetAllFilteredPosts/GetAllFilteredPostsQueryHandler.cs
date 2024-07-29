using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;

internal class GetAllFilteredPostsQueryHandler : IQueryHandler<GetAllFilteredPostsQuery, PostPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetAllFilteredPostsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postRepository;
    }

    public async Task<PostPaginationQueryViewModel> Handle(
        GetAllFilteredPostsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostFilteredCollectionReadQuery>(request);

        var posts = await _postReadRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostPaginationQueryViewModel>(posts);

        return response;
    }
}
