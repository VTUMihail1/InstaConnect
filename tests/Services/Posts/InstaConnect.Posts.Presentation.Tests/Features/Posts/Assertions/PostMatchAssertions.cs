using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this UpdatePostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this GetPostByIdApiResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p => p.Matches(post, user));
    }

    public static void ShouldSatisfy(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostByIdApiResponse> response, Post post, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostsApiResponse> response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, user, request));
    }

    public static void ShouldSatisfy(this Post post, AddPostApiRequest request)
    {
        post.ShouldSatisfy(p => p.Matches(request));
    }

    public static void ShouldSatisfy(this Post post, UpdatePostApiRequest request)
    {
        post.ShouldSatisfy(p => p.Matches(request));
    }
}
