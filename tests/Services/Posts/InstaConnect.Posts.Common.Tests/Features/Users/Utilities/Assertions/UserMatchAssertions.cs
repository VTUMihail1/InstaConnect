using InstaConnect.Common.Tests.Utilities.Assertions;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ProblemDetails problemDetails,
        string id)
    {
        problemDetails.ShouldSatisfyNotFound(UserExceptionErrorMessages.GetNotFoundMessage(id));
    }
}
