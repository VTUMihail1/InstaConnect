using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQuery, ICollection<PostCommentLikeQueryViewModel>>
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

    public async Task<ICollection<PostCommentLikeQueryViewModel>> Handle(GetAllPostCommentLikesQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _instaConnectMapper.Map<CollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeReadRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostCommentLikeQueryViewModel>>(postCommentLikes);

        return response;
    }
}
