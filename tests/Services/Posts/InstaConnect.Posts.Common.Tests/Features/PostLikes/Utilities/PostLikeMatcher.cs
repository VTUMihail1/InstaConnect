using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static PostLike IsPostLike(PostLike postLike, AddPostLikeCommandRequest command)
    {
        return Matcher.Is<PostLike>(p => p.IsSatisfied(postLike, command));
    }

    public static PostLike IsPostLike(PostLike postLike)
    {
        return Matcher.Is<PostLike>(p => p.IsSatisfied(postLike));
    }

    public static GetAllPostLikesQueryRequest IsGetAllPostLikesQuery(GetAllPostLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostLikesQueryRequest>(p => p.IsSatisfied(request));
    }

    public static GetPostLikeByIdQueryRequest IsGetPostLikeByIdQuery(GetPostLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQueryRequest>(p => p.IsSatisfied(request));
    }

    public static AddPostLikeCommandRequest IsAddPostLikeCommand(AddPostLikeApiRequest request)
    {
        return Matcher.Is<AddPostLikeCommandRequest>(p => p.IsSatisfied(request));
    }

    public static DeletePostLikeCommandRequest IsDeletePostLikeCommand(DeletePostLikeApiRequest request)
    {
        return Matcher.Is<DeletePostLikeCommandRequest>(p => p.IsSatisfied(request));
    }

    public static GetAllPostLikesQuery IsGetAllPostLikesRequest(GetAllPostLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostLikesQuery>(p => p.IsSatisfied(request));
    }

    public static GetPostLikeByIdQuery IsGetPostLikeByIdRequest(GetPostLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQuery>(p => p.IsSatisfied(request));
    }

    public static AddPostLikeCommand IsAddPostLikeRequest(AddPostLikeCommandRequest request)
    {
        return Matcher.Is<AddPostLikeCommand>(p => p.IsSatisfied(request));
    }

    public static DeletePostLikeCommand IsDeletePostLikeRequest(DeletePostLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostLikeCommand>(p => p.IsSatisfied(request));
    }
}
