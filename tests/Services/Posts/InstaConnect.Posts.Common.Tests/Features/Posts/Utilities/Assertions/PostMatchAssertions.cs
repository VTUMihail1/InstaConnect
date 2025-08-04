using System.Threading.Tasks;

using FluentAssertions;

using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Assertions;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Models;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
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
    public static void ShouldSatisfy(this AddPostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post));
    }

    public static void ShouldSatisfy(this UpdatePostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post));
    }

    public static void ShouldSatisfy(this GetPostByIdQueryResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post, user));
    }

    public static void ShouldSatisfy(this GetAllPostsQueryResponse response, Post post, User user, GetAllPostsQueryRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post, user, request));
    }

    public static void ShouldSatisfy(this AddPostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post));
    }

    public static void ShouldSatisfy(this UpdatePostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post));
    }

    public static void ShouldSatisfy(this GetPostByIdApiResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post, user));
    }

    public static void ShouldSatisfy(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(post, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(post));
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(post));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostByIdApiResponse> response, Post post, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(post, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostsApiResponse> response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(post, user, request));
    }

    public static void ShouldSatisfy(this Post post, AddPostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this Post post, UpdatePostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this Post post, AddPostApiRequest request)
    {
        post.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this Post post, UpdatePostApiRequest request)
    {
        post.ShouldSatisfy(p => p.IsSatisfied(request));
    }
}
