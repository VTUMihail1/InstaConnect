using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using NSubstitute;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostMatcher
{
    public static PostQueryParameters IsPostQueryParameters(GetAllPostsQuery query)
    {
        return Matcher.Is<PostQueryParameters>(p => p.Filter.UserId == query.Filter.UserId &&
                                                    p.Filter.UserName == query.Filter.UserName &&
                                                    p.Filter.Title == query.Filter.Title &&
                                                    p.Pagination.Page == query.Pagination.Page &&
                                                    p.Pagination.PageSize == query.Pagination.PageSize &&
                                                    p.Sorting.Order == query.Sorting.Order &&
                                                    p.Sorting.Property == query.Sorting.Property);
    }

    public static Post IsPost(Post post, AddPostCommand command)
    {
        return Matcher.Is<Post>(p => p.Id == post.Id &&
                                     p.UserId == command.CurrentUserId &&
                                     p.Title == command.Title &&
                                     p.Content == command.Content &&
                                     p.CreatedAt == post.CreatedAt &&
                                     p.UpdatedAt == post.UpdatedAt);
    }

    public static Post IsPost(Post post, UpdatePostCommand command)
    {
        return Matcher.Is<Post>(p => p.Id == post.Id &&
                                     p.UserId == post.UserId &&
                                     p.Title == command.Title &&
                                     p.Content == command.Content &&
                                     p.CreatedAt == post.CreatedAt &&
                                     p.UpdatedAt == post.UpdatedAt);
    }

    public static Post IsPost(Post post)
    {
        return Matcher.Is<Post>(p => p.Id == post.Id &&
                                     p.UserId == post.UserId &&
                                     p.Title == post.Title &&
                                     p.Content == post.Content &&
                                     p.CreatedAt == post.CreatedAt &&
                                     p.UpdatedAt == post.UpdatedAt);
    }

    public static GetAllPostsQuery IsGetAllPostsQuery(GetAllPostsRequest request)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.Filter.UserId == request.Filter.UserId &&
                                                 p.Filter.UserName == request.Filter.UserName &&
                                                 p.Filter.Title == request.Filter.Title &&
                                                 p.Pagination.Page == request.Pagination.Page &&
                                                 p.Pagination.PageSize == request.Pagination.PageSize &&
                                                 p.Sorting.Order == request.Sorting.Order &&
                                                 p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostByIdQuery IsGetPostByIdQuery(GetPostByIdRequest request)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.Id == request.Id);
    }

    public static AddPostCommand IsAddPostCommand(AddPostRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.Title == request.Body.Title &&
                                               p.Content == request.Body.Content &&
                                               p.CurrentUserId == request.CurrentUserId);
    }

    public static UpdatePostCommand IsUpdatePostCommand(UpdatePostRequest command)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.Id == command.Id &&
                                                  p.Title == command.Body.Title &&
                                                  p.Content == command.Body.Content &&
                                                  p.CurrentUserId == command.CurrentUserId);
    }

    public static DeletePostCommand IsDeletePostCommand(DeletePostRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.Id == request.Id &&
                                                  p.CurrentUserId == request.CurrentUserId);
    }
}
