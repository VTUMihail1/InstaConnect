using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeApiResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(this GetPostLikeByIdApiResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesApiResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesApiResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostLikeApiResponse> response, PostLike postLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostLikeByIdApiResponse> response, PostLike postLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostLikesApiResponse> response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLikes, request));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeApiRequest request)
    {
        postLike.ShouldSatisfy(p => p.Matches(request));
    }
}
