using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(
        this AddPostLikeCommandResponse response,
        PostLike postLike,
        AddPostLikeCommandRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, request));
    }

    public static void ShouldSatisfy(
        this GetPostLikeByIdQueryResponse response,
        PostLike postLike,
        GetPostLikeByIdQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesQueryResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, postLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesQueryResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(post, postLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesForUserQueryResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(user, postLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesForUserQueryResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(user, postLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.Matches(request));
    }
}
