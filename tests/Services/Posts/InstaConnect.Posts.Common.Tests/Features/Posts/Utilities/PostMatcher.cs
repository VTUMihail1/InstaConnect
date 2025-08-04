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
    public static Post IsPost(Post post, AddPostCommandRequest request)
    {
        return Matcher.Is<Post>(p => p.IsSatisfied(request));
    }

    public static Post IsPost(Post post, UpdatePostCommandRequest request)
    {
        return Matcher.Is<Post>(p => p.IsSatisfied(request));
    }

    public static Post IsPost(Post post)
    {
        return Matcher.Is<Post>(p => p.IsSatisfied(post));
    }

    public static GetAllPostsQueryRequest IsGetAllPostsQuery(GetAllPostsApiRequest request)
    {
        return Matcher.Is<GetAllPostsQueryRequest>(p => p.IsSatisfied(request));
    }

    public static GetPostByIdQueryRequest IsGetPostByIdQuery(GetPostByIdApiRequest request)
    {
        return Matcher.Is<GetPostByIdQueryRequest>(p => p.IsSatisfied(request));
    }

    public static AddPostCommandRequest IsAddPostCommand(AddPostApiRequest request)
    {
        return Matcher.Is<AddPostCommandRequest>(p => p.IsSatisfied(request));
    }

    public static UpdatePostCommandRequest IsUpdatePostCommand(UpdatePostApiRequest request)
    {
        return Matcher.Is<UpdatePostCommandRequest>(p => p.IsSatisfied(request));
    }

    public static DeletePostCommandRequest IsDeletePostCommand(DeletePostApiRequest request)
    {
        return Matcher.Is<DeletePostCommandRequest>(p => p.IsSatisfied(request));
    }
    public static GetAllPostsQuery IsGetAllPostsRequest(GetAllPostsQueryRequest request)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.IsSatisfied(request));
    }

    public static GetPostByIdQuery IsGetPostByIdRequest(GetPostByIdQueryRequest request)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.IsSatisfied(request));
    }

    public static AddPostCommand IsAddPostRequest(AddPostCommandRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.IsSatisfied(request));
    }

    public static UpdatePostCommand IsUpdatePostRequest(UpdatePostCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.IsSatisfied(request));
    }

    public static DeletePostCommand IsDeletePostRequest(DeletePostCommandRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.IsSatisfied(request));
    }
}
