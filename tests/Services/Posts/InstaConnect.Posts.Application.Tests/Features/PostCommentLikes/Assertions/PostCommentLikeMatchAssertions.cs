using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentLikeCommandResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike));
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesQueryResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesQueryResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Matches(request));
    }
}
