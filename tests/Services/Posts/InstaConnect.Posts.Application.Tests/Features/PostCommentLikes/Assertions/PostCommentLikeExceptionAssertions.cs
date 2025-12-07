using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentNotFoundExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
            r => r.Id,
            r => r.CommentId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentNotFoundExceptionAsync(
            r => r.Id,
            r => r.CommentId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentNotFoundExceptionAsync<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>(
            r => r.Id,
            r => r.CommentId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentNotFoundExceptionAsync<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>(
            r => r.Id,
            r => r.CommentId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentLikeNotFoundExceptionAsync<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
        this IApplicationSender sender,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostCommentLikeNotFoundException, TRequest>(
            PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
            new(
                new(
                    new(idPropertyExpression(request)),
                    commentIdPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostCommentLikeNotFoundException, TRequest, TResponse>(
            PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
            new(
                new(
                    new(idPropertyExpression(request)),
                    commentIdPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostCommentLikeAlreadyExistsException, TRequest>(
            PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
            new(
                new(
                    new(idPropertyExpression(request)),
                    commentIdPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostCommentLikeAlreadyExistsException, TRequest, TResponse>(
            PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
            new(
                new(
                    new(idPropertyExpression(request)),
                    commentIdPropertyExpression(request)),
                new(userIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }
}
