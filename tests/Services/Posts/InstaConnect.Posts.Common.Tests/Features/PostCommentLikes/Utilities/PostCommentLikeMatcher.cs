using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMatcher
{
    public static PostCommentLike IsPostCommentLike(PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest command)
    {
        return Matcher.Is<PostCommentLike>(p => p.IsSatisfied(postCommentLike, command));
    }

    public static PostCommentLike IsPostCommentLike(PostCommentLike postCommentLike)
    {
        return Matcher.Is<PostCommentLike>(p => p.IsSatisfied(postCommentLike));
    }

    public static GetAllPostCommentLikesQueryRequest IsGetAllPostCommentLikesQuery(GetAllPostCommentLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQueryRequest>(p => p.IsSatisfied(request));
    }

    public static GetPostCommentLikeByIdQueryRequest IsGetPostCommentLikeByIdQuery(GetPostCommentLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQueryRequest>(p => p.IsSatisfied(request));
    }

    public static AddPostCommentLikeCommandRequest IsAddPostCommentLikeCommand(AddPostCommentLikeApiRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommandRequest>(p => p.IsSatisfied(request));
    }

    public static DeletePostCommentLikeCommandRequest IsDeletePostCommentLikeCommand(DeletePostCommentLikeApiRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommandRequest>(p => p.IsSatisfied(request));
    }

    public static GetAllPostCommentLikesQuery IsGetAllPostCommentLikesRequest(GetAllPostCommentLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQuery>(p => p.IsSatisfied(request));
    }

    public static GetPostCommentLikeByIdQuery IsGetPostCommentLikeByIdRequest(GetPostCommentLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQuery>(p => p.IsSatisfied(request));
    }

    public static AddPostCommentLikeCommand IsAddPostCommentLikeRequest(AddPostCommentLikeCommandRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommand>(p => p.IsSatisfied(request));
    }

    public static DeletePostCommentLikeCommand IsDeletePostCommentLikeRequest(DeletePostCommentLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommand>(p => p.IsSatisfied(request));
    }
}
