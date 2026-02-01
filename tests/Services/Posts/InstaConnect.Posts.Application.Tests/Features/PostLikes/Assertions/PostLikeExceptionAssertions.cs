using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetAllPostLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllPostLikesForUserQueryRequest, GetAllPostLikesForUserQueryResponse>(
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostLikeCommandRequest, AddPostLikeCommandResponse>(
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<AddPostLikeCommandRequest, AddPostLikeCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetAllPostLikesQueryRequest, GetAllPostLikesQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostLikeNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostLikeNotFoundExceptionAsync(
            r => r.Id,
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostLikeNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostLikeNotFoundExceptionAsync<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>(
            r => r.Id,
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostLikeAlreadyExistsExceptionAsync<AddPostLikeCommandRequest, AddPostLikeCommandResponse>(
            r => r.Id,
            r => r.UserId,
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostLikeNotFoundException, TRequest>(
            PostLikeExceptionErrorMessages.GetNotFoundMessage(
            new(
                new(idPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostLikeNotFoundException, TRequest, TResponse>(
            PostLikeExceptionErrorMessages.GetNotFoundMessage(
            new(
                new(idPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostLikeAlreadyExistsException, TRequest>(
            PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
            new(
                new(idPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostLikeAlreadyExistsException, TRequest, TResponse>(
            PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
            new(
                new(idPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }
}
