using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

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
