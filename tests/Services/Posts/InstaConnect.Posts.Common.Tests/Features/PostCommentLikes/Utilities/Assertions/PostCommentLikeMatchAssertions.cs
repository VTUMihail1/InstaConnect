using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this AddPostCommentLikeCommandResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postCommentLike));
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postCommentLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentLikesQueryResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postCommentLike, user, request));
    }

    public static void ShouldSatisfy(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postCommentLike));
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postCommentLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostCommentLikesApiResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postCommentLike, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentLikeApiResponse> response, PostCommentLike postCommentLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postCommentLike));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentLikeByIdApiResponse> response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postCommentLike, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentLikesApiResponse> response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postCommentLike, user, request));
    }
}
