using AutoMapper;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Data.Models.Filters.Posts;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;

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
