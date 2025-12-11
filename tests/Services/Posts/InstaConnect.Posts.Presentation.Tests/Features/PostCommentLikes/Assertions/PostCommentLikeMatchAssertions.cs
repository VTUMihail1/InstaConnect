using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike));
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentLikesApiResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentLikeApiResponse> response, PostCommentLike postCommentLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentLikeByIdApiResponse> response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentLikesApiResponse> response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike, user, request));
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Matches(request));
    }
}
