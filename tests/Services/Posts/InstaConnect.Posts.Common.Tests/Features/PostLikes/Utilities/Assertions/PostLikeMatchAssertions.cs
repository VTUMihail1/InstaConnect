using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Id == postLike.Id &&
                                    p.LikeId == postLike.LikeId &&
                                    p.CreatedAt == postLike.CreatedAt &&
                                    p.UpdatedAt == postLike.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == postLike.Id &&
                                    p.Data.LikeId == postLike.LikeId &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(pp => pp.Data.All(p => p.Id == postLike.Id &&
                                                      p.LikeId == postLike.LikeId &&
                                                      p.User.Id == user.Id &&
                                                      p.User.Name == user.Name &&
                                                      p.User.ProfileImage == user.ProfileImage) &&
                                     pp.Page == request.Pagination.Page &&
                                     pp.PageSize == request.Pagination.PageSize &&
                                     pp.TotalCount == pp.Data.Count &&
                                     pp.HasPreviousPage == pp.Page > 1 &&
                                     pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this AddPostLikeApiResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Id == postLike.Id &&
                                    p.LikeId == postLike.LikeId &&
                                    p.CreatedAt == postLike.CreatedAt &&
                                    p.UpdatedAt == postLike.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostLikeByIdApiResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == postLike.Id &&
                                    p.Data.LikeId == postLike.LikeId &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostLikesApiResponse response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        response.ShouldSatisfy(pp => pp.Data.All(p => p.Id == postLike.Id &&
                                                      p.LikeId == postLike.LikeId &&
                                                      p.User.Id == user.Id &&
                                                      p.User.Name == user.Name &&
                                                      p.User.ProfileImage == user.ProfileImage) &&
                                     pp.Page == request.Pagination.Page &&
                                     pp.PageSize == request.Pagination.PageSize &&
                                     pp.TotalCount == pp.Data.Count &&
                                     pp.HasPreviousPage == pp.Page > 1 &&
                                     pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this ActionResult<AddPostLikeApiResponse> response, PostLike postLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == postLike.Id &&
                                    p.LikeId == postLike.LikeId &&
                                    p.CreatedAt == postLike.CreatedAt &&
                                    p.UpdatedAt == postLike.UpdatedAt);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostLikeByIdApiResponse> response, PostLike postLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Data.Id == postLike.Id &&
                                                     p.Data.LikeId == postLike.LikeId &&
                                                     p.Data.User.Id == user.Id &&
                                                     p.Data.User.Name == user.Name &&
                                                     p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostLikesApiResponse> response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Data.All(p => p.Id == postLike.Id &&
                                                                       p.LikeId == postLike.LikeId &&
                                                                       p.User.Id == user.Id &&
                                                                       p.User.Name == user.Name &&
                                                                       p.User.ProfileImage == user.ProfileImage) &&
                                                pp.Page == request.Pagination.Page &&
                                                pp.PageSize == request.Pagination.PageSize &&
                                                pp.TotalCount == pp.Data.Count &&
                                                pp.HasPreviousPage == pp.Page > 1 &&
                                                pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.Id == request.Id &&
                                    p.UserId == request.UserId);
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeApiRequest request)
    {
        postLike.ShouldSatisfy(p => p.Id == request.Id &&
                                    p.UserId == request.UserId);
    }
}
