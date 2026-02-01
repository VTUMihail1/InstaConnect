using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentProblemDetailsAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostCommentByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostCommentByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentForbidden(
        this ApplicationProblemDetails problemDetails,
        DeletePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentForbidden(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostCommentForbidden(
        this ApplicationProblemDetails problemDetails,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentForbidden(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request);
    }

    internal static void ShouldSatisfyPostCommentNotFound<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyNotFound(
            PostCommentExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(commentIdPropertyExpression(request)))));
    }

    internal static void ShouldSatisfyPostCommentForbidden<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyForbidden(
            PostCommentExceptionErrorMessages.GetForbiddenMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(commentIdPropertyExpression(request))),
                new(userIdPropertyExpression(request))));
    }
}
