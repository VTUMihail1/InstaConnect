using System.Reflection;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using Mapster;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {

        var postQueryResponse = new PostQueryResponse(
            post.Id,
            post.Title,
            post.Content,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postQueryResponses = new List<PostQueryResponse>() { postQueryResponse };

        var response = new GetAllPostsQueryResponse(
            postQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostByIdApiRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostByIdQueryResponse(
            new(
                post.Id,
                post.Title,
                post.Content,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommandResponse(post.Id, post.CreatedAt, post.UpdatedAt);

        applicationSender
            .SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender applicationSender,
        UpdatePostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePostCommandResponse(post.Id, post.CreatedAt, post.UpdatedAt);

        applicationSender
            .SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllQuery(
        this IPostService postService,
        GetAllPostsQueryRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {
        var posts = new List<Post>() { post };
        var response = new PostCollection(
            posts,
            request.Pagination.Page,
            request.Pagination.PageSize,
            posts.Count,
            false,
            false);

        postService
            .GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostService postService,
        GetPostByIdQueryRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {
        postService
            .GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken)
            .ReturnsResponse(post);
    }

    public static void SetupAddCommand(
        this IPostService postService,
        AddPostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken)
            .ReturnsResponse(post);
    }

    public static void SetupUpdateCommand(
        this IPostService postService,
        UpdatePostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken)
            .ReturnsResponse(post);
    }
}
