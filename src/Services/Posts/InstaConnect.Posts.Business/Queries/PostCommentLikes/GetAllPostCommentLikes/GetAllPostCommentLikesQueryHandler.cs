using AutoMapper;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Data.Models.Filters.PostCommentLikes;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;

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
        var collectionQuery = _instaConnectMapper.Map<PostCommentLikeCollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeReadRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikePaginationQueryViewModel>(postCommentLikes);

        return response;
    }
}
