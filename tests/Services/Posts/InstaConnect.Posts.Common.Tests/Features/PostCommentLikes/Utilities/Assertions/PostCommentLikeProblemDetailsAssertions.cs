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
        string commentLikeId)
    {
        problemDetails.ShouldSatisfyNotFound(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(id, commentId, commentLikeId));
    }

    public static void ShouldSatisfyPostCommentLikeForbidden(
        this ProblemDetails problemDetails,
        string id,
        string commentId,
        string commentLikeId,
        string userId)
    {
        problemDetails.ShouldSatisfyForbidden(PostCommentLikeExceptionErrorMessages.GetForbiddenMessage(id, commentId, commentLikeId, userId));
    }
}
