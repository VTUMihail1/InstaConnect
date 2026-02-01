using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQueryRequest IsGetAllPostLikesQueryRequest(GetAllPostLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostLikesQueryRequest>(p => p.Matches(request));
    }

    public static GetAllPostLikesForUserQueryRequest IsGetAllPostLikesForUserQueryRequest(GetAllPostLikesForUserApiRequest request)
    {
        return Matcher.Is<GetAllPostLikesForUserQueryRequest>(p => p.Matches(request));
    }

    public static GetPostLikeByIdQueryRequest IsGetPostLikeByIdQueryRequest(GetPostLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQueryRequest>(p => p.Matches(request));
    }

    public static AddPostLikeCommandRequest IsAddPostLikeCommandRequest(AddPostLikeApiRequest request)
    {
        return Matcher.Is<AddPostLikeCommandRequest>(p => p.Matches(request));
    }

    public static DeletePostLikeCommandRequest IsDeletePostLikeCommandRequest(DeletePostLikeApiRequest request)
    {
        return Matcher.Is<DeletePostLikeCommandRequest>(p => p.Matches(request));
    }
}
