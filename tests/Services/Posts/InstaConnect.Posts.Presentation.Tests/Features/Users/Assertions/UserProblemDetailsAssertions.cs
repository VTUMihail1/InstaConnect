using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        UpdateUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyUserNotFound(
        this ApplicationProblemDetails problemDetails,
        DeleteUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserNotFound(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyUserAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        AddUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserAlreadyExists(
            r => r.Id,
            request);
    }

    public static void ShouldSatisfyUserNameAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        AddUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserNameAlreadyExists(
            r => r.Name,
            request);
    }

    public static void ShouldSatisfyUserNameAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        UpdateUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserNameAlreadyExists(
            r => r.Name,
            request);
    }

    public static void ShouldSatisfyUserEmailAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        AddUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserEmailAlreadyExists(
            r => r.Email,
            request);
    }

    public static void ShouldSatisfyUserEmailAlreadyExists(
        this ApplicationProblemDetails problemDetails,
        UpdateUserCommandRequest request)
    {
        problemDetails.ShouldSatisfyUserEmailAlreadyExists(
            r => r.Email,
            request);
    }

    internal static void ShouldSatisfyUserNotFound<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyNotFound(
            UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
    }

    internal static void ShouldSatisfyUserAlreadyExists<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> idPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyBadRequest(
            UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))));
    }

    internal static void ShouldSatisfyUserNameAlreadyExists<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> namePropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyBadRequest(
            UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))));
    }

    internal static void ShouldSatisfyUserEmailAlreadyExists<TRequest>(
        this ApplicationProblemDetails problemDetails,
        Func<TRequest, string> emailPropertyExpression,
        TRequest request)
    {
        problemDetails.ShouldSatisfyBadRequest(
            UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))));
    }
}
