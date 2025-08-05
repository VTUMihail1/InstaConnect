using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;

public static class PostCommentProblemDetailsAssertions
{
    public static void ShouldSatisfyPostCommentNotFound(
        this ProblemDetails problemDetails,
        string id,
        string commentId)
    {
        problemDetails.ShouldSatisfyNotFound(PostCommentExceptionErrorMessages.GetNotFoundMessage(id, commentId));
    }

    public static void ShouldSatisfyPostCommentForbidden(
        this ProblemDetails problemDetails,
        string id,
        string commentId,
        string userId)
    {
        problemDetails.ShouldSatisfyForbidden(PostCommentExceptionErrorMessages.GetForbiddenMessage(id, commentId, userId));
    }
}
