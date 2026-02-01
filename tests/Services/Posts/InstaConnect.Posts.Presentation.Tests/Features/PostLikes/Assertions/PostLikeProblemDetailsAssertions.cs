using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeProblemDetailsAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostLikesForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostLikeNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostLikeNotFound(
            r => r.Id,
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostLikeNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostLikeNotFound(
            r => r.Id,
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostLikeAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        AddPostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyPostLikeAlreadyExists(
            r => r.Id,
            r => r.UserId,
            request);
    }

    internal static void ShouldSatisfyPostLikeNotFound<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyNotFound(
            PostLikeExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))));
    }

    internal static void ShouldSatisfyPostLikeAlreadyExists<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyBadRequest(
            PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))));
    }
}
