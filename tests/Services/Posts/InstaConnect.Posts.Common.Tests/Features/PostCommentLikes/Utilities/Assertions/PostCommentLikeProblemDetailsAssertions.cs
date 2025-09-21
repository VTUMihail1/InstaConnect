using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;

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
