using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQuery, PostLikePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostLikeReadRepository _postLikeReadRepository;

    public GetAllPostLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostLikeReadRepository postLikeRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postLikeReadRepository = postLikeRepository;
    }

    public async Task<PostLikePaginationQueryViewModel> Handle(
        GetAllPostLikesQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostLikeFilteredCollectionReadQuery>(request);

        var postLikes = await _postLikeReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikePaginationQueryViewModel>(postLikes);

        return response;
    }
}
