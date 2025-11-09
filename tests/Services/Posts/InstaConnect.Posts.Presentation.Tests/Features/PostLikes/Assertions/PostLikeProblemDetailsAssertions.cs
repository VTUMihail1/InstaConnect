namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeProblemDetailsAssertions
{
    public static void ShouldSatisfyPostLikeNotFound(
        this ProblemDetails problemDetails,
        string id,
        string userId)
    {
        problemDetails.ShouldSatisfyNotFound(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, userId));
    }

    public static void ShouldSatisfyPostLikeAlreadyExists(
        this ProblemDetails problemDetails,
        string id,
        string userId)
    {
        problemDetails.ShouldSatisfyForbidden(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id, userId));
    }
}
