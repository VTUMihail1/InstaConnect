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
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using NSubstitute;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostMatcher
{
    public static GetAllPostsQueryRequest IsGetAllPostsQueryRequest(GetAllPostsApiRequest request)
    {
        return Matcher.Is<GetAllPostsQueryRequest>(p => p.Filter.UserId == request.Filter.UserId &&
                                                        p.Filter.UserName == request.Filter.UserName &&
                                                        p.Filter.Title == request.Filter.Title &&
                                                        p.Pagination.Page == request.Pagination.Page &&
                                                        p.Pagination.PageSize == request.Pagination.PageSize &&
                                                        p.Sorting.Order == request.Sorting.Order &&
                                                        p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostByIdQueryRequest IsGetPostByIdQueryRequest(GetPostByIdApiRequest request)
    {
        return Matcher.Is<GetPostByIdQueryRequest>(p => p.Id == request.Id);
    }

    public static AddPostCommandRequest IsAddPostCommandRequest(AddPostApiRequest request)
    {
        return Matcher.Is<AddPostCommandRequest>(p => p.Title == request.Body.Title &&
                                                      p.Content == request.Body.Content &&
                                                      p.UserId == request.UserId);
    }

    public static UpdatePostCommandRequest IsUpdatePostCommandRequest(UpdatePostApiRequest request)
    {
        return Matcher.Is<UpdatePostCommandRequest>(p => p.Id == request.Id &&
                                                         p.Title == request.Body.Title &&
                                                         p.Content == request.Body.Content &&
                                                         p.UserId == request.UserId);
    }

    public static DeletePostCommandRequest IsDeletePostCommandRequest(DeletePostApiRequest request)
    {
        return Matcher.Is<DeletePostCommandRequest>(p => p.Id == request.Id &&
                                                         p.UserId == request.UserId);
    }
    public static GetAllPostsQuery IsGetAllPostsQuery(GetAllPostsQueryRequest request)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.Filter.UserId == request.Filter.UserId &&
                                                 p.Filter.UserName == request.Filter.UserName &&
                                                 p.Filter.Title == request.Filter.Title &&
                                                 p.Pagination.Page == request.Pagination.Page &&
                                                 p.Pagination.PageSize == request.Pagination.PageSize &&
                                                 p.Sorting.Order == request.Sorting.Order &&
                                                 p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostByIdQuery IsGetPostByIdQuery(GetPostByIdQueryRequest request)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.Id == request.Id);
    }

    public static AddPostCommand IsAddPostCommand(AddPostCommandRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.Title == request.Title &&
                                               p.Content == request.Content &&
                                               p.UserId == request.UserId);
    }

    public static UpdatePostCommand IsUpdatePostCommand(UpdatePostCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.Id == request.Id &&
                                                  p.Title == request.Title &&
                                                  p.Content == request.Content &&
                                                  p.UserId == request.UserId);
    }

    public static DeletePostCommand IsDeletePostCommand(DeletePostCommandRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.Id == request.Id &&
                                                  p.UserId == request.UserId);
    }
}
