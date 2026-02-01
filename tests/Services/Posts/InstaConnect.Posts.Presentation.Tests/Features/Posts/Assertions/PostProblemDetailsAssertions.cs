using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostProblemDetailsAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        AddPostApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        UpdatePostApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        GetPostByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostNotFound(
        this ApplicationProblemDetails problemDetails,
        DeletePostApiRequest request)
    {
        problemDetails.ShouldSatisfyPostNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyPostForbidden(
        this ApplicationProblemDetails problemDetails,
        UpdatePostApiRequest request)
    {
        problemDetails.ShouldSatisfyPostForbidden(
            r => r.Id,
            r => r.UserId,
            request);
    }

    public static void ShouldSatisfyPostForbidden(
        this ApplicationProblemDetails problemDetails,
        DeletePostApiRequest request)
    {
        problemDetails.ShouldSatisfyPostForbidden(
            r => r.Id,
            r => r.UserId,
            request);
    }

    internal static void ShouldSatisfyPostNotFound<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyNotFound(
            PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
    }

    internal static void ShouldSatisfyPostForbidden<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyForbidden(
            PostExceptionErrorMessages.GetForbiddenMessage(
                new(idPropertyExpression(request)),
                new(userIdPropertyExpression(request))));
    }
}
