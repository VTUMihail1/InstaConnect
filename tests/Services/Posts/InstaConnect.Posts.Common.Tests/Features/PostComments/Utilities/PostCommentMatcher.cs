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
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

using NSubstitute;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static PostComment IsPostComment(PostComment postComment, AddPostCommentCommandRequest request)
    {
        return Matcher.Is<PostComment>(p => p.IsSatisfied(request));
    }

    public static PostComment IsPostComment(PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        return Matcher.Is<PostComment>(p => p.IsSatisfied(request));
    }

    public static PostComment IsPostComment(PostComment postComment)
    {
        return Matcher.Is<PostComment>(p => p.IsSatisfied(postComment));
    }

    public static GetAllPostCommentsQueryRequest IsGetAllPostCommentsQuery(GetAllPostCommentsApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQueryRequest>(p => p.IsSatisfied(request));
    }

    public static GetPostCommentByIdQueryRequest IsGetPostCommentByIdQuery(GetPostCommentByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQueryRequest>(p => p.IsSatisfied(request));
    }

    public static AddPostCommentCommandRequest IsAddPostCommentCommand(AddPostCommentApiRequest request)
    {
        return Matcher.Is<AddPostCommentCommandRequest>(p => p.IsSatisfied(request));
    }

    public static UpdatePostCommentCommandRequest IsUpdatePostCommentCommand(UpdatePostCommentApiRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommandRequest>(p => p.IsSatisfied(request));
    }

    public static DeletePostCommentCommandRequest IsDeletePostCommentCommand(DeletePostCommentApiRequest request)
    {
        return Matcher.Is<DeletePostCommentCommandRequest>(p => p.IsSatisfied(request));
    }
    public static GetAllPostCommentsQuery IsGetAllPostCommentsRequest(GetAllPostCommentsQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQuery>(p => p.IsSatisfied(request));
    }

    public static GetPostCommentByIdQuery IsGetPostCommentByIdRequest(GetPostCommentByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQuery>(p => p.IsSatisfied(request));
    }

    public static AddPostCommentCommand IsAddPostCommentRequest(AddPostCommentCommandRequest request)
    {
        return Matcher.Is<AddPostCommentCommand>(p => p.IsSatisfied(request));
    }

    public static UpdatePostCommentCommand IsUpdatePostCommentRequest(UpdatePostCommentCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommand>(p => p.IsSatisfied(request));
    }

    public static DeletePostCommentCommand IsDeletePostCommentRequest(DeletePostCommentCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentCommand>(p => p.IsSatisfied(request));
    }
}
