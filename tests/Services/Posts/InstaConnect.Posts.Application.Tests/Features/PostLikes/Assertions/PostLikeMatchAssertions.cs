using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(this GetPostLikeByIdQueryResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesQueryResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLikes, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostLikesQueryResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postLikes, request, termTransformer));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.Matches(request));
    }
}
