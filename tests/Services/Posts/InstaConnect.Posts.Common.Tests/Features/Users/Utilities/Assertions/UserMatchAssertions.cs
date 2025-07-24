using InstaConnect.Common.Tests.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfyUserNotFoundProblemDetails(
        this ProblemDetails problemDetails,
        string id)
    {
        problemDetails.ShouldSatisfyNotFound(UserExceptionErrorMessages.GetNotFoundMessage(id));
    }
}
