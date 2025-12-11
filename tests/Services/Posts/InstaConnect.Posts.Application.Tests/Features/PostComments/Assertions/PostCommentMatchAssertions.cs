using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this UpdatePostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this GetPostCommentByIdQueryResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentsQueryResponse response, PostComment postComment, User user, GetAllPostCommentsQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, user, request));
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }
}
