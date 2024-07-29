using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;

internal class GetAllFilteredPostLikesQueryHandler : IQueryHandler<GetAllFilteredPostLikesQuery, PostLikePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostLikeReadRepository _postLikeReadRepository;

    public GetAllFilteredPostLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostLikeReadRepository postLikeRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postLikeReadRepository = postLikeRepository;
    }

    public async Task<PostLikePaginationQueryViewModel> Handle(
        GetAllFilteredPostLikesQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostLikeFilteredCollectionReadQuery>(request);

        var postLikes = await _postLikeReadRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikePaginationQueryViewModel>(postLikes);

        return response;
    }
}
