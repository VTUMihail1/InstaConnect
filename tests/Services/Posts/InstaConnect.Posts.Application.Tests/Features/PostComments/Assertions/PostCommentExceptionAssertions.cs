using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostCommentCommandRequest, AddPostCommentCommandResponse>(
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllPostCommentsForUserQueryRequest, GetAllPostCommentsForUserQueryResponse>(
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<AddPostCommentCommandRequest, AddPostCommentCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this IApplicationSender sender,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostNotFoundExceptionAsync<GetAllPostCommentsQueryRequest, GetAllPostCommentsQueryResponse>(
            r => r.Id,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this IApplicationSender sender,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentNotFoundExceptionAsync<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>(
            r => r.Id,
            r => r.CommentId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommentCommandRequest request,
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
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentNotFoundExceptionAsync<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>(
            r => r.Id,
            r => r.CommentId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentForbiddenExceptionAsync(
        this IApplicationSender sender,
        DeletePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentForbiddenExceptionAsync(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowPostCommentForbiddenExceptionAsync(
        this IApplicationSender sender,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowPostCommentForbiddenExceptionAsync<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>(
            r => r.Id,
            r => r.CommentId,
            r => r.UserId,
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostCommentNotFoundException, TRequest>(
            PostCommentExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(commentIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostCommentNotFoundException, TRequest, TResponse>(
            PostCommentExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(commentIdPropertyExpression(request)))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest
    {
        await sender.ShouldThrowAsync<PostCommentForbiddenException, TRequest>(
            PostCommentExceptionErrorMessages.GetForbiddenMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(commentIdPropertyExpression(request))),
                new(userIdPropertyExpression(request))),
            request,
            cancellationToken);
    }

    internal static async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest, TResponse>(
        this IApplicationSender sender,
        Func<TRequest, string> idPropertyExpression,
        Func<TRequest, string> commentIdPropertyExpression,
        Func<TRequest, string> userIdPropertyExpression,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TResponse>
    {
        await sender.ShouldThrowAsync<PostCommentForbiddenException, TRequest, TResponse>(
            PostCommentExceptionErrorMessages.GetForbiddenMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(commentIdPropertyExpression(request))),
                new(userIdPropertyExpression(request))),
            request,
            cancellationToken);
    }
}
