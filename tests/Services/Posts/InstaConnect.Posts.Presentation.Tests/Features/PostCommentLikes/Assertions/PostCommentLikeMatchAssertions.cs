using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(
        this AddPostCommentLikeApiResponse response,
        PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
    }

    public static void ShouldSatisfy(
        this GetPostCommentLikeByIdApiResponse response,
        PostCommentLike postCommentLike,
        GetPostCommentLikeByIdApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesApiResponse response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesApiResponse response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesForUserApiResponse response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentLikesForUserApiResponse response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this ActionResult<AddPostCommentLikeApiResponse> response,
        PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetPostCommentLikeByIdApiResponse> response,
        PostCommentLike postCommentLike,
        GetPostCommentLikeByIdApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostCommentLikesApiResponse> response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, postCommentLikes, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostCommentLikesForUserApiResponse> response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, postCommentLikes, request));
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Matches(request));
    }
}
