using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeVerifiers
{
    public static bool IsSatisfied(this PostCommentLikeQueryResponse response, PostCommentLike postCommentLike, User user)
    {
        return response.Id == postCommentLike.Id &&
               response.CommentId == postCommentLike.CommentId &&
               response.CommentLikeId == postCommentLike.CommentLikeId &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }

    public static bool IsSatisfied(this PostCommentLikeApiResponse response, PostCommentLike postCommentLike, User user)
    {
        return response.Id == postCommentLike.Id &&
               response.CommentId == postCommentLike.CommentId &&
               response.CommentLikeId == postCommentLike.CommentLikeId &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }

    public static bool IsSatisfied(this AddPostCommentLikeCommandResponse response, PostCommentLike postCommentLike)
    {
        return response.Id == postCommentLike.Id &&
               response.CommentId == postCommentLike.CommentId &&
               response.CommentLikeId == postCommentLike.CommentLikeId &&
               response.CreatedAt == postCommentLike.CreatedAt &&
               response.UpdatedAt == postCommentLike.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike, User user)
    {
        return response.Data.IsSatisfied(postCommentLike, user);
    }

    public static bool IsSatisfied(this GetAllPostCommentLikesQueryResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesQueryRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(postCommentLike, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        return response.Id == postCommentLike.Id &&
               response.CommentId == postCommentLike.CommentId &&
               response.CommentLikeId == postCommentLike.CommentLikeId &&
               response.CreatedAt == postCommentLike.CreatedAt &&
               response.UpdatedAt == postCommentLike.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, User user)
    {
        return response.Data.IsSatisfied(postCommentLike, user);
    }

    public static bool IsSatisfied(this GetAllPostCommentLikesApiResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(postCommentLike, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        return postCommentLike.Id == request.Id &&
               postCommentLike.CommentId == request.CommentId &&
               postCommentLike.UserId == request.UserId;
    }

    public static bool IsSatisfied(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        return postCommentLike.Id == request.Id &&
               postCommentLike.CommentId == request.CommentId &&
               postCommentLike.UserId == request.UserId;
    }

    public static bool IsSatisfied(this PostCommentLike postCommentLike, PostCommentLike pl, AddPostCommentLikeCommandRequest command)
    {
        return postCommentLike.Id == pl.Id &&
               postCommentLike.CommentId == pl.CommentId &&
               postCommentLike.CommentLikeId == pl.CommentLikeId &&
               postCommentLike.UserId == command.UserId &&
               postCommentLike.CreatedAt == pl.CreatedAt &&
               postCommentLike.UpdatedAt == pl.UpdatedAt;
    }

    public static bool IsSatisfied(this PostCommentLike postCommentLike, PostCommentLike pl)
    {
        return postCommentLike.Id == pl.Id &&
               postCommentLike.CommentId == pl.CommentId &&
               postCommentLike.CommentLikeId == pl.CommentLikeId &&
               postCommentLike.UserId == pl.UserId &&
               postCommentLike.CreatedAt == pl.CreatedAt &&
               postCommentLike.UpdatedAt == pl.UpdatedAt;
    }

    public static bool IsSatisfied(this GetAllPostCommentLikesQueryRequest request, GetAllPostCommentLikesApiRequest r)
    {
        return request.Filter.Id == r.Filter.Id &&
               request.Filter.CommentId == r.Filter.CommentId &&
               request.Filter.UserId == r.Filter.UserId &&
               request.Filter.UserName == r.Filter.UserName &&
               request.Pagination.Page == r.Pagination.Page &&
               request.Pagination.PageSize == r.Pagination.PageSize &&
               request.Sorting.Order == r.Sorting.Order &&
               request.Sorting.Property == r.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostCommentLikeByIdQueryRequest request, GetPostCommentLikeByIdApiRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.CommentLikeId == r.CommentLikeId;
    }

    public static bool IsSatisfied(this AddPostCommentLikeCommandRequest request, AddPostCommentLikeApiRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this DeletePostCommentLikeCommandRequest request, DeletePostCommentLikeApiRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.CommentLikeId == r.CommentLikeId &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this GetAllPostCommentLikesQuery request, GetAllPostCommentLikesQueryRequest r)
    {
        return request.Filter.Id == r.Filter.Id &&
               request.Filter.CommentId == r.Filter.CommentId &&
               request.Filter.UserId == r.Filter.UserId &&
               request.Filter.UserName == r.Filter.UserName &&
               request.Pagination.Page == r.Pagination.Page &&
               request.Pagination.PageSize == r.Pagination.PageSize &&
               request.Sorting.Order == r.Sorting.Order &&
               request.Sorting.Property == r.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostCommentLikeByIdQuery request, GetPostCommentLikeByIdQueryRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.CommentLikeId == r.CommentLikeId;
    }

    public static bool IsSatisfied(this AddPostCommentLikeCommand request, AddPostCommentLikeCommandRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this DeletePostCommentLikeCommand request, DeletePostCommentLikeCommandRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this PostCommentLikeAddedEvent addedEvent, PostCommentLike postCommentLike)
    {
        return addedEvent.Id == postCommentLike.Id &&
               addedEvent.CommentId == postCommentLike.CommentId &&
               addedEvent.CommentLikeId == postCommentLike.CommentLikeId &&
               addedEvent.UserId == postCommentLike.UserId &&
               addedEvent.CreatedAt == postCommentLike.CreatedAt &&
               addedEvent.UpdatedAt == postCommentLike.UpdatedAt;
    }

    public static bool IsSatisfied(this PostCommentLikeDeletedEvent deletedEvent, PostCommentLike postCommentLike)
    {
        return deletedEvent.Id == postCommentLike.Id &&
               deletedEvent.CommentId == postCommentLike.CommentId &&
               deletedEvent.CommentLikeId == postCommentLike.CommentLikeId;
    }
}
