using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

using NSubstitute;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQueryRequest IsGetAllPostCommentsQuery(GetAllPostCommentsApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQueryRequest>(p => p.Filter.Id == request.Filter.Id &&
                                                               p.Filter.UserId == request.Filter.UserId &&
                                                               p.Filter.UserName == request.Filter.UserName &&
                                                               p.Pagination.Page == request.Pagination.Page &&
                                                               p.Pagination.PageSize == request.Pagination.PageSize &&
                                                               p.Sorting.Order == request.Sorting.Order &&
                                                               p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostCommentByIdQueryRequest IsGetPostCommentByIdQuery(GetPostCommentByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQueryRequest>(p => p.Id == request.Id &&
                                                               p.CommentId == request.CommentId);
    }

    public static AddPostCommentCommandRequest IsAddPostCommentCommand(AddPostCommentApiRequest request)
    {
        return Matcher.Is<AddPostCommentCommandRequest>(p => p.Id == request.Id &&
                                                             p.Content == request.Body.Content &&
                                                             p.UserId == request.UserId);
    }

    public static UpdatePostCommentCommandRequest IsUpdatePostCommentCommand(UpdatePostCommentApiRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommandRequest>(p => p.Id == request.Id &&
                                                                p.CommentId == request.CommentId &&
                                                                p.Content == request.Body.Content &&
                                                                p.UserId == request.UserId);
    }

    public static DeletePostCommentCommandRequest IsDeletePostCommentCommand(DeletePostCommentApiRequest request)
    {
        return Matcher.Is<DeletePostCommentCommandRequest>(p => p.Id == request.Id &&
                                                                p.CommentId == request.CommentId &&
                                                                p.UserId == request.UserId);
    }
    public static GetAllPostCommentsQuery IsGetAllPostCommentsRequest(GetAllPostCommentsQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQuery>(p => p.Filter.Id == request.Filter.Id &&
                                                        p.Filter.UserId == request.Filter.UserId &&
                                                        p.Filter.UserName == request.Filter.UserName &&
                                                        p.Pagination.Page == request.Pagination.Page &&
                                                        p.Pagination.PageSize == request.Pagination.PageSize &&
                                                        p.Sorting.Order == request.Sorting.Order &&
                                                        p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostCommentByIdQuery IsGetPostCommentByIdRequest(GetPostCommentByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQuery>(p => p.Id == request.Id &&
                                                        p.CommentId == request.CommentId);
    }

    public static AddPostCommentCommand IsAddPostCommentRequest(AddPostCommentCommandRequest request)
    {
        return Matcher.Is<AddPostCommentCommand>(p => p.Id == request.Id &&
                                                      p.Content == request.Content &&
                                                      p.UserId == request.UserId);
    }

    public static UpdatePostCommentCommand IsUpdatePostCommentRequest(UpdatePostCommentCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommand>(p => p.Id == request.Id &&
                                                         p.CommentId == request.CommentId &&
                                                         p.Content == request.Content &&
                                                         p.UserId == request.UserId);
    }

    public static DeletePostCommentCommand IsDeletePostCommentRequest(DeletePostCommentCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentCommand>(p => p.Id == request.Id &&
                                                         p.CommentId == request.CommentId &&
                                                         p.UserId == request.UserId);
    }
}
