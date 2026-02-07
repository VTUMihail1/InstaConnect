using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(
        this AddPostLikeApiResponse response,
        PostLike postLike,
        AddPostLikeApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, request));
    }

    public static void ShouldSatisfy(
        this GetPostLikeByIdApiResponse response,
        PostLike postLike,
        GetPostLikeByIdApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesApiResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, postLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesApiResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(post, postLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesForUserApiResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(user, postLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesForUserApiResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(user, postLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this ActionResult<AddPostLikeApiResponse> response,
        PostLike postLike,
        AddPostLikeApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetPostLikeByIdApiResponse> response,
        PostLike postLike,
        GetPostLikeByIdApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostLikesApiResponse> response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, postLikes, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostLikesForUserApiResponse> response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, postLikes, request));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeApiRequest request)
    {
        postLike.ShouldSatisfy(p => p.Matches(request));
    }
}
