using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Models;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

public static class PostLikeVerifiers
{
    public static bool IsSatisfied(this PostLikeQueryResponse response, PostLike postLike, User user)
    {
        return response.Id == postLike.Id &&
               response.LikeId == postLike.LikeId &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }

    public static bool IsSatisfied(this PostLikeApiResponse response, PostLike postLike, User user)
    {
        return response.Id == postLike.Id &&
               response.LikeId == postLike.LikeId &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }

    public static bool IsSatisfied(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        return response.Id == postLike.Id &&
               response.LikeId == postLike.LikeId &&
               response.CreatedAt == postLike.CreatedAt &&
               response.UpdatedAt == postLike.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        return response.Data.IsSatisfied(postLike, user);
    }

    public static bool IsSatisfied(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(postLike, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this AddPostLikeApiResponse response, PostLike postLike)
    {
        return response.Id == postLike.Id &&
               response.LikeId == postLike.LikeId &&
               response.CreatedAt == postLike.CreatedAt &&
               response.UpdatedAt == postLike.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostLikeByIdApiResponse response, PostLike postLike, User user)
    {
        return response.Data.IsSatisfied(postLike, user);
    }

    public static bool IsSatisfied(this GetAllPostLikesApiResponse response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(postLike, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        return postLike.Id == request.Id && postLike.UserId == request.UserId;
    }

    public static bool IsSatisfied(this PostLike postLike, AddPostLikeApiRequest request)
    {
        return postLike.Id == request.Id && postLike.UserId == request.UserId;
    }

    public static bool IsSatisfied(this PostLike postLike, PostLike pl, AddPostLikeCommandRequest command)
    {
        return postLike.Id == pl.Id &&
               postLike.LikeId == pl.LikeId &&
               postLike.UserId == command.UserId &&
               postLike.CreatedAt == pl.CreatedAt &&
               postLike.UpdatedAt == pl.UpdatedAt;
    }

    public static bool IsSatisfied(this PostLike postLike, PostLike pl)
    {
        return postLike.Id == pl.Id &&
               postLike.LikeId == pl.LikeId &&
               postLike.UserId == pl.UserId &&
               postLike.CreatedAt == pl.CreatedAt &&
               postLike.UpdatedAt == pl.UpdatedAt;
    }

    public static bool IsSatisfied(this GetAllPostLikesQueryRequest request, GetAllPostLikesApiRequest r)
    {
        return request.Filter.Id == r.Filter.Id &&
               request.Filter.UserId == r.Filter.UserId &&
               request.Filter.UserName == r.Filter.UserName &&
               request.Pagination.Page == r.Pagination.Page &&
               request.Pagination.PageSize == r.Pagination.PageSize &&
               request.Sorting.Order == r.Sorting.Order &&
               request.Sorting.Property == r.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostLikeByIdQueryRequest request, GetPostLikeByIdApiRequest r)
    {
        return request.Id == r.Id &&
               request.LikeId == r.LikeId;
    }

    public static bool IsSatisfied(this AddPostLikeCommandRequest request, AddPostLikeApiRequest r)
    {
        return request.Id == r.Id &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this DeletePostLikeCommandRequest request, DeletePostLikeApiRequest r)
    {
        return request.Id == r.Id &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this GetAllPostLikesQuery request, GetAllPostLikesQueryRequest r)
    {
        return request.Filter.Id == r.Filter.Id &&
               request.Filter.UserId == r.Filter.UserId &&
               request.Filter.UserName == r.Filter.UserName &&
               request.Pagination.Page == r.Pagination.Page &&
               request.Pagination.PageSize == r.Pagination.PageSize &&
               request.Sorting.Order == r.Sorting.Order &&
               request.Sorting.Property == r.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostLikeByIdQuery request, GetPostLikeByIdQueryRequest r)
    {
        return request.Id == r.Id &&
               request.LikeId == r.LikeId;
    }

    public static bool IsSatisfied(this AddPostLikeCommand request, AddPostLikeCommandRequest r)
    {
        return request.Id == r.Id &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this DeletePostLikeCommand request, DeletePostLikeCommandRequest r)
    {
        return request.Id == r.Id &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this PostLikeAddedEvent addedEvent, PostLike postLike)
    {
        return addedEvent.Id == postLike.Id &&
               addedEvent.LikeId == postLike.LikeId &&
               addedEvent.UserId == postLike.UserId &&
               addedEvent.CreatedAt == postLike.CreatedAt &&
               addedEvent.UpdatedAt == postLike.UpdatedAt;
    }

    public static bool IsSatisfied(this PostLikeDeletedEvent deletedEvent, PostLike postLike)
    {
        return deletedEvent.Id == postLike.Id &&
               deletedEvent.LikeId == postLike.LikeId;
    }
}
