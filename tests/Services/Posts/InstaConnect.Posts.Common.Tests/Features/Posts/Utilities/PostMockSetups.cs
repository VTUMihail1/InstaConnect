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
    public static void SetupGetAllQuery(
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
            .SendAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
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
            .SendAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommand(
        this IApplicationSender applicationSender,
        AddPostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommandResponse(post.Id, post.CreatedAt, post.UpdatedAt);

        applicationSender
            .SendAsync(PostMatcher.IsAddPostCommand(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommand(
        this IApplicationSender applicationSender,
        UpdatePostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePostCommandResponse(post.Id, post.CreatedAt, post.UpdatedAt);

        applicationSender
            .SendAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllRequest(
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
            .GetAllAsync(PostMatcher.IsGetAllPostsRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdRequest(
        this IPostService postService,
        GetPostByIdQueryRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {
        postService
            .GetByIdAsync(PostMatcher.IsGetPostByIdRequest(request), cancellationToken)
            .ReturnsResponse(post);
    }

    public static void SetupAddRequest(
        this IPostService postService,
        AddPostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .AddAsync(PostMatcher.IsAddPostRequest(request), cancellationToken)
            .ReturnsResponse(post);
    }

    public static void SetupUpdateRequest(
        this IPostService postService,
        UpdatePostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .UpdateAsync(PostMatcher.IsUpdatePostRequest(request), cancellationToken)
            .ReturnsResponse(post);
    }
}
