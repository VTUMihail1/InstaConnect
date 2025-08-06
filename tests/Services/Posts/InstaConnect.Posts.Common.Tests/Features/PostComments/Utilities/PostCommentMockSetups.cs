using System.Reflection;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Application.Features.PostComments.Models;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

using Mapster;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentsApiRequest request,
        PostComment postComment,
        User user,
        CancellationToken cancellationToken)
    {

        var postCommentQueryResponse = new PostCommentQueryResponse(
            postComment.Id,
            postComment.CommentId,
            postComment.Content,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postCommentQueryResponses = new List<PostCommentQueryResponse>() { postCommentQueryResponse };

        var response = new GetAllPostCommentsQueryResponse(
            postCommentQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postCommentQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentByIdApiRequest request,
        PostComment postComment,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentByIdQueryResponse(
            new(
                postComment.Id,
                postComment.CommentId,
                postComment.Content,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentCommandResponse(postComment.Id, postComment.CommentId, postComment.CreatedAt, postComment.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender applicationSender,
        UpdatePostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePostCommentCommandResponse(postComment.Id, postComment.CommentId, postComment.CreatedAt, postComment.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllQuery(
        this IPostCommentService postCommentService,
        GetAllPostCommentsQueryRequest request,
        PostComment postComment,
        User user,
        CancellationToken cancellationToken)
    {
        var postComments = new List<PostComment>() { postComment };
        var response = new PostCommentCollection(
            postComments,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postComments.Count,
            false,
            false);

        postCommentService
            .GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostCommentService postCommentService,
        GetPostCommentByIdQueryRequest request,
        PostComment postComment,
        User user,
        CancellationToken cancellationToken)
    {
        postCommentService
            .GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
            .ReturnsResponse(postComment);
    }

    public static void SetupAddCommand(
        this IPostCommentService postCommentService,
        AddPostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment);
    }

    public static void SetupUpdateCommand(
        this IPostCommentService postCommentService,
        UpdatePostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment);
    }
}
