using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
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

    public static void ShouldSatisfy(this GetPostByIdApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(
        this GetAllPostsApiResponse response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(posts, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostsApiResponse response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(posts, request, termTransformer));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostByIdApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post));
    }
    public static void ShouldSatisfy(
        this ActionResult<GetAllPostsApiResponse> response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(posts, request));
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
