using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQuery, PostCommentLikePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentLikeReadRepository _postCommentLikeReadRepository;

    public GetAllPostCommentLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentLikeReadRepository postCommentLikeReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentLikeReadRepository = postCommentLikeReadRepository;
    }

    public async Task<PostCommentLikePaginationQueryViewModel> Handle(
        GetAllPostCommentLikesQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentLikeCollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikePaginationQueryViewModel>(postCommentLikes);

        return response;
    }
}
