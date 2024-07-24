using InstaConnect.Posts.Data.Models.Filters.PostCommentLikes;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

internal class GetAllFilteredPostCommentLikesQueryHandler : IQueryHandler<GetAllFilteredPostCommentLikesQuery, ICollection<PostCommentLikeQueryViewModel>>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentLikeReadRepository _postCommentLikeRepository;

    public GetAllFilteredPostCommentLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentLikeReadRepository postCommentLikeRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task<ICollection<PostCommentLikeQueryViewModel>> Handle(GetAllFilteredPostCommentLikesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentLikeFilteredCollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostCommentLikeQueryViewModel>>(postCommentLikes);

        return response;
    }
}
