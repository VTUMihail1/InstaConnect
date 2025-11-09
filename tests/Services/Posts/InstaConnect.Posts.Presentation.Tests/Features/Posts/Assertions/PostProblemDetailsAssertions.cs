namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostProblemDetailsAssertions
{
    public static void ShouldSatisfyPostNotFound(
        this ProblemDetails problemDetails,
        string id)
    {
        problemDetails.ShouldSatisfyNotFound(PostExceptionErrorMessages.GetNotFoundMessage(id));
    }

    public static void ShouldSatisfyPostForbidden(
        this ProblemDetails problemDetails,
        string id,
        string userId)
    {
        problemDetails.ShouldSatisfyForbidden(PostExceptionErrorMessages.GetForbiddenMessage(id, userId));
    }
}
