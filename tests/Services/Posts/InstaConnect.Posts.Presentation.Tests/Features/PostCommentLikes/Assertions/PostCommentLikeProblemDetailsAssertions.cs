using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeProblemDetailsAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostCommentLikesForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostCommentLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostCommentLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentNotFound(
            r => r.Id,
            r => r.CommentId,
            request);
    }

    public static void ShouldSatisfyPostCommentLikeNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentLikeNotFound(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostCommentLikeNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostCommentLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentLikeNotFound(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostCommentLikeAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostCommentLikeAlreadyExists(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request);
    }

    internal static void ShouldSatisfyPostCommentLikeNotFound<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyNotFound(
            PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(
                        new(idPropertyExpression(request)),
                        commentIdPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))));
    }

    internal static void ShouldSatisfyPostCommentLikeAlreadyExists<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyBadRequest(
            PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
                new(
                    new(
                        new(idPropertyExpression(request)),
                        commentIdPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))));
    }
}
