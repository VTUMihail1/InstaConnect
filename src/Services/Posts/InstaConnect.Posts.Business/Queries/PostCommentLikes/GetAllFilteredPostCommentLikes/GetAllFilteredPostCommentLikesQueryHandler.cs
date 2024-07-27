using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Data.Models.Filters.PostCommentLikes;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

internal class GetAllFilteredPostCommentLikesQueryHandler : IQueryHandler<GetAllFilteredPostCommentLikesQuery, PostCommentLikePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentLikeReadRepository _postCommentLikeReadRepository;

    public GetAllFilteredPostCommentLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentLikeReadRepository postCommentLikeReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentLikeReadRepository = postCommentLikeReadRepository;
    }

    public async Task<PostCommentLikePaginationQueryViewModel> Handle(
        GetAllFilteredPostCommentLikesQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentLikeFilteredCollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeReadRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikePaginationQueryViewModel>(postCommentLikes);

        return response;
    }
}
