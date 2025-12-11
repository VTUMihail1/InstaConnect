using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Matches(postLike));
    }

    public static void ShouldSatisfy(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postLike, user, request));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.Matches(request));
    }
}
