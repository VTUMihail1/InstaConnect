using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;

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
