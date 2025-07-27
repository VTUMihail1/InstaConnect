using System.Threading.Tasks;

using FluentAssertions;

using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this Post post, AddPostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.UserId == request.CurrentUserId &&
                                p.Title == request.Title &&
                                p.Content == request.Content);
    }

    public static void ShouldSatisfy(this Post post, UpdatePostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.Id == request.Id &&
                                p.UserId == request.CurrentUserId &&
                                p.Title == request.Title &&
                                p.Content == request.Content);
    }

    public static void ShouldSatisfy(this Post post, AddPostApiRequest request)
    {
        post.ShouldSatisfy(p => p.UserId == request.CurrentUserId &&
                                p.Title == request.Body.Title &&
                                p.Content == request.Body.Content);
    }

    public static void ShouldSatisfy(this Post post, UpdatePostApiRequest request)
    {
        post.ShouldSatisfy(p => p.Id == request.Id &&
                                p.UserId == request.CurrentUserId &&
                                p.Title == request.Body.Title &&
                                p.Content == request.Body.Content);
    }

    public static void ShouldSatisfy(this AddPostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAt &&
                                    p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this UpdatePostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAt &&
                                    p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostByIdQueryResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p =>
            p.Data.Id == post.Id &&
            p.Data.User.Id == user.Id &&
            p.Data.User.Name == user.UserName &&
            p.Data.User.ProfileImage == user.ProfileImage &&
            p.Data.Title == post.Title &&
            p.Data.Content == post.Content);
    }

    public static void ShouldSatisfy(this GetAllPostsQueryResponse response, Post post, User user, GetAllPostsQueryRequest request)
    {
        response.ShouldSatisfy(pp =>
            pp.Data.All(p =>
                p.Id == post.Id &&
                p.User.Id == user.Id &&
                p.User.Name == user.UserName &&
                p.User.ProfileImage == user.ProfileImage &&
                p.Title == post.Title &&
                p.Content == post.Content) &&
            pp.Page == request.Pagination.Page &&
            pp.PageSize == request.Pagination.PageSize &&
            pp.TotalCount == pp.Data.Count &&
            pp.HasPreviousPage == pp.Page > 1 &&
            pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this AddPostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAt &&
                                    p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this UpdatePostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAt &&
                                    p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostByIdApiResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p =>
            p.Data.Id == post.Id &&
            p.Data.User.Id == user.Id &&
            p.Data.User.Name == user.UserName &&
            p.Data.User.ProfileImage == user.ProfileImage &&
            p.Data.Title == post.Title &&
            p.Data.Content == post.Content);
    }

    public static void ShouldSatisfy(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldSatisfy(pp =>
            pp.Data.All(p =>
                p.Id == post.Id &&
                p.User.Id == user.Id &&
                p.User.Name == user.UserName &&
                p.User.ProfileImage == user.ProfileImage &&
                p.Title == post.Title &&
                p.Content == post.Content) &&
            pp.Page == request.Pagination.Page &&
            pp.PageSize == request.Pagination.PageSize &&
            pp.TotalCount == pp.Data.Count &&
            pp.HasPreviousPage == pp.Page > 1 &&
            pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this ActionResult<AddPostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == post.Id &&
                                                     p.CreatedAt == post.CreatedAt &&
                                                     p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == post.Id &&
                                                     p.CreatedAt == post.CreatedAt &&
                                                     p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostByIdApiResponse> response, Post post, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p =>
            p.Data.Id == post.Id &&
            p.Data.User.Id == user.Id &&
            p.Data.User.Name == user.UserName &&
            p.Data.User.ProfileImage == user.ProfileImage &&
            p.Data.Title == post.Title &&
            p.Data.Content == post.Content);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostsApiResponse> response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp =>
            pp.Data.All(p =>
                p.Id == post.Id &&
                p.User.Id == user.Id &&
                p.User.Name == user.UserName &&
                p.User.ProfileImage == user.ProfileImage &&
                p.Title == post.Title &&
                p.Content == post.Content) &&
            pp.Page == request.Pagination.Page &&
            pp.PageSize == request.Pagination.PageSize &&
            pp.TotalCount == pp.Data.Count &&
            pp.HasPreviousPage == pp.Page > 1 &&
            pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }
    public static void ShouldSatisfyPostNotFoundProblemDetails(
        this ProblemDetails problemDetails,
        string id)
    {
        problemDetails.ShouldSatisfyNotFound(PostExceptionErrorMessages.GetNotFoundMessage(id));
    }

    public static void ShouldSatisfyPostForbiddenProblemDetails(
        this ProblemDetails problemDetails,
        string id,
        string userId)
    {
        problemDetails.ShouldSatisfyForbidden(PostExceptionErrorMessages.GetForbiddenMessage(id, userId));
    }
}
