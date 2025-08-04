using InstaConnect.Common.Tests.Assertions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeApiRequest request)
    {
        postLike.ShouldSatisfy(p => p.IsSatisfied(request));
    }

    public static void ShouldSatisfy(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postLike));
    }

    public static void ShouldSatisfy(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postLike, user, request));
    }

    public static void ShouldSatisfy(this AddPostLikeApiResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postLike));
    }

    public static void ShouldSatisfy(this GetPostLikeByIdApiResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postLike, user));
    }

    public static void ShouldSatisfy(this GetAllPostLikesApiResponse response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        response.ShouldSatisfy(p => p.IsSatisfied(postLike, user, request));
    }

    public static void ShouldSatisfy(this ActionResult<AddPostLikeApiResponse> response, PostLike postLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postLike));
    }

    public static void ShouldSatisfy(this ActionResult<GetPostLikeByIdApiResponse> response, PostLike postLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postLike, user));
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostLikesApiResponse> response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.IsSatisfied(postLike, user, request));
    }
}
