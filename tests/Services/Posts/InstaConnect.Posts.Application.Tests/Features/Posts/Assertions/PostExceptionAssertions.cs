using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostCommandRequest, AddPostCommandResponse>(
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<UpdatePostCommandRequest, UpdatePostCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostByIdQueryRequest, GetPostByIdQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostForbiddenExceptionAsync(
        this IApplicationSender sender,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostForbiddenExceptionAsync<UpdatePostCommandRequest, UpdatePostCommandResponse>(
            r => r.Id,
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostForbiddenExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostForbiddenExceptionAsync(
            r => r.Id,
            r => r.UserId,
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostNotFoundExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostNotFoundException, TRequest>(
            PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostNotFoundExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostNotFoundException, TRequest, TResponse>(
            PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostForbiddenExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostForbiddenException, TRequest>(
            PostExceptionErrorMessages.GetForbiddenMessage(new(idPropertyExpression(request)), new(userIdPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostForbiddenExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostForbiddenException, TRequest, TResponse>(
            PostExceptionErrorMessages.GetForbiddenMessage(new(idPropertyExpression(request)), new(userIdPropertyExpression(request))),
            request,
            cancellationToken);
    }
}
