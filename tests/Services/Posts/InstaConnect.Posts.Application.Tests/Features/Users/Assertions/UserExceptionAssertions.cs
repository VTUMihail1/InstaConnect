using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<UpdateUserCommandRequest, UpdateUserCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserAlreadyExistsExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNameAlreadyExistsExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
            r => r.Name,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNameAlreadyExistsExceptionAsync<UpdateUserCommandRequest, UpdateUserCommandResponse>(
            r => r.Name,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
            r => r.Email,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync<UpdateUserCommandRequest, UpdateUserCommandResponse>(
            r => r.Email,
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserNotFoundExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<UserNotFoundException, TRequest>(
            UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserNotFoundExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<UserNotFoundException, TRequest, TResponse>(
            UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<UserAlreadyExistsException, TRequest>(
            UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<UserAlreadyExistsException, TRequest, TResponse>(
            UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> namePropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<UserNameAlreadyExistsException, TRequest>(
            UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> namePropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<UserNameAlreadyExistsException, TRequest, TResponse>(
            UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> emailPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<UserEmailAlreadyExistsException, TRequest>(
            UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> emailPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<UserEmailAlreadyExistsException, TRequest, TResponse>(
            UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))),
            request,
            cancellationToken);
    }
}
