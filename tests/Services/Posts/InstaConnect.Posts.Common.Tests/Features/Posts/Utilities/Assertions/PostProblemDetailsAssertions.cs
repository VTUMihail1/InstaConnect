using InstaConnect.Common.Tests.Utilities.Assertions;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

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
