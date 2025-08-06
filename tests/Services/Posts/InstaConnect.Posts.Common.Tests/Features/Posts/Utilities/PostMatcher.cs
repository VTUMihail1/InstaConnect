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
    public static GetAllPostsQueryRequest IsGetAllPostsQuery(GetAllPostsApiRequest request)
    {
        return Matcher.Is<GetAllPostsQueryRequest>(p => p.Filter.UserId == request.Filter.UserId &&
                                                        p.Filter.UserName == request.Filter.UserName &&
                                                        p.Filter.Title == request.Filter.Title &&
                                                        p.Pagination.Page == request.Pagination.Page &&
                                                        p.Pagination.PageSize == request.Pagination.PageSize &&
                                                        p.Sorting.Order == request.Sorting.Order &&
                                                        p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostByIdQueryRequest IsGetPostByIdQuery(GetPostByIdApiRequest request)
    {
        return Matcher.Is<GetPostByIdQueryRequest>(p => p.Id == request.Id);
    }

    public static AddPostCommandRequest IsAddPostCommand(AddPostApiRequest request)
    {
        return Matcher.Is<AddPostCommandRequest>(p => p.Title == request.Body.Title &&
                                                      p.Content == request.Body.Content &&
                                                      p.UserId == request.UserId);
    }

    public static UpdatePostCommandRequest IsUpdatePostCommand(UpdatePostApiRequest request)
    {
        return Matcher.Is<UpdatePostCommandRequest>(p => p.Id == request.Id &&
                                                         p.Title == request.Body.Title &&
                                                         p.Content == request.Body.Content &&
                                                         p.UserId == request.UserId);
    }

    public static DeletePostCommandRequest IsDeletePostCommand(DeletePostApiRequest request)
    {
        return Matcher.Is<DeletePostCommandRequest>(p => p.Id == request.Id &&
                                                         p.UserId == request.UserId);
    }
    public static GetAllPostsQuery IsGetAllPostsRequest(GetAllPostsQueryRequest request)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.Filter.UserId == request.Filter.UserId &&
                                                 p.Filter.UserName == request.Filter.UserName &&
                                                 p.Filter.Title == request.Filter.Title &&
                                                 p.Pagination.Page == request.Pagination.Page &&
                                                 p.Pagination.PageSize == request.Pagination.PageSize &&
                                                 p.Sorting.Order == request.Sorting.Order &&
                                                 p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostByIdQuery IsGetPostByIdRequest(GetPostByIdQueryRequest request)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.Id == request.Id);
    }

    public static AddPostCommand IsAddPostRequest(AddPostCommandRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.Title == request.Title &&
                                               p.Content == request.Content &&
                                               p.UserId == request.UserId);
    }

    public static UpdatePostCommand IsUpdatePostRequest(UpdatePostCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.Id == request.Id &&
                                                  p.Title == request.Title &&
                                                  p.Content == request.Content &&
                                                  p.UserId == request.UserId);
    }

    public static DeletePostCommand IsDeletePostRequest(DeletePostCommandRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.Id == request.Id &&
                                                  p.UserId == request.UserId);
    }
}
