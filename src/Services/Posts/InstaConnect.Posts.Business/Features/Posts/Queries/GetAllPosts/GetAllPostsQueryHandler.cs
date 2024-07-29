using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, PostPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetAllPostsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
    }

    public async Task<PostPaginationQueryViewModel> Handle(
        GetAllPostsQuery request,
        CancellationToken cancellationToken)
    {
        var collectionQuery = _instaConnectMapper.Map<PostCollectionReadQuery>(request);

        var posts = await _postReadRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostPaginationQueryViewModel>(posts);

        return response;
    }
}
