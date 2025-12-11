using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentLikeCommandResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike));
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentLikesQueryResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postCommentLike, user, request));
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Matches(request));
    }
}
