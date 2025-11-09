namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ProblemDetails problemDetails,
        string id)
    {
        problemDetails.ShouldSatisfyNotFound(UserExceptionErrorMessages.GetNotFoundMessage(id));
    }
}
