using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this UpdatePostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(this GetPostByIdQueryResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Matches(post));
    }

    public static void ShouldSatisfy(
        this GetAllPostsQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(posts, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostsQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsQueryRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(posts, request, termTransformer));
    }

    public static void ShouldSatisfy(this Post post, AddPostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.Matches(request));
    }

    public static void ShouldSatisfy(this Post post, UpdatePostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.Matches(request));
    }
}
