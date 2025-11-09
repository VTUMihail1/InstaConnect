namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeProblemDetailsAssertions
{
    public static void ShouldSatisfyPostCommentLikeNotFound(
        this ProblemDetails problemDetails,
        string id,
        string commentId,
        string userId)
    {
        problemDetails.ShouldSatisfyNotFound(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(id, commentId, userId));
    }

    public static void ShouldSatisfyPostCommentLikeAlreadyExists(
        this ProblemDetails problemDetails,
        string id,
        string commentId,
        string userId)
    {
        problemDetails.ShouldSatisfyForbidden(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(id, commentId, userId));
    }
}
