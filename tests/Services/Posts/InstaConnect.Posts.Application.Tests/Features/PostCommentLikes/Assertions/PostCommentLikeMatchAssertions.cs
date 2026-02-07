using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(
        this AddPostCommentLikeCommandResponse response,
        PostCommentLike postCommentLike,
        AddPostCommentLikeCommandRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
    }

    public static void ShouldSatisfy(
        this GetPostCommentLikeByIdQueryResponse response,
        PostCommentLike postCommentLike,
        GetPostCommentLikeByIdQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesQueryResponse response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesQueryResponse response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesForUserQueryResponse response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesForUserQueryResponse response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserQueryRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Matches(request));
    }
}
