using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment));
    }

    public static void ShouldSatisfy(this UpdatePostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment));
    }

    public static void ShouldSatisfy(this GetPostCommentByIdQueryResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentsQueryResponse response, PostComment postComment, User user, GetAllPostCommentsQueryRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment, user, request));
    }

    public static void ShouldSatisfy(this AddPostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment));
    }

    public static void ShouldSatisfy(this UpdatePostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment));
    }

    public static void ShouldSatisfy(this GetPostCommentByIdApiResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentsApiResponse response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postComment, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postComment));
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postComment));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentByIdApiResponse> response, PostComment postComment, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postComment, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentsApiResponse> response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postComment, user, request));
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.IsSatisfied(request));
    }
}
