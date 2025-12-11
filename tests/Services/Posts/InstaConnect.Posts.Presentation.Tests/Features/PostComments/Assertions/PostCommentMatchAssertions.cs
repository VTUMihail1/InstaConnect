using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this UpdatePostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this GetPostCommentByIdApiResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentsApiResponse response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentByIdApiResponse> response, PostComment postComment, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentsApiResponse> response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, user, request));
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }
}
