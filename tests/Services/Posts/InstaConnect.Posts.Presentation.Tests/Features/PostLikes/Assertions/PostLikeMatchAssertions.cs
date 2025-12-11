using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeApiResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(this GetPostLikeByIdApiResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostLikesApiResponse response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostLikeApiResponse> response, PostLike postLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostLikeByIdApiResponse> response, PostLike postLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostLikesApiResponse> response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike, user, request));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeApiRequest request)
    {
        postLike.ShouldSatisfy(p => p.Matches(request));
    }
}
