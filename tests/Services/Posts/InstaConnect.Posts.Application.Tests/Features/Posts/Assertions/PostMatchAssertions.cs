using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommandResponse response, Post post, AddPostCommandRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, request));
    }

    public static void ShouldSatisfy(this UpdatePostCommandResponse response, Post post, UpdatePostCommandRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, request));
    }

    public static void ShouldSatisfy(this GetPostByIdQueryResponse response, Post post, GetPostByIdQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, request));
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

    public static void ShouldSatisfy(
        this GetAllPostsForUserQueryResponse response,
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(user, posts, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostsForUserQueryResponse response,
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserQueryRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(user, posts, request, termTransformer));
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
