namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQuery IsGetAllPostLikesQuery(GetAllPostLikesQueryRequest request, CommonIncludeQuery<PostLikeIncludeProperty> include)
    {
        return Matcher.Is<GetAllPostLikesQuery>(p => p.Matches(request, include));
    }

    public static GetPostLikeByIdQuery IsGetPostLikeByIdQuery(GetPostLikeByIdQueryRequest request, CommonIncludeQuery<PostLikeIncludeProperty> include)
    {
        return Matcher.Is<GetPostLikeByIdQuery>(p => p.Matches(request, include));
    }

    public static AddPostLikeCommand IsAddPostLikeCommand(AddPostLikeCommandRequest request)
    {
        return Matcher.Is<AddPostLikeCommand>(p => p.Matches(request));
    }

    public static DeletePostLikeCommand IsDeletePostLikeCommand(DeletePostLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostLikeCommand>(p => p.Matches(request));
    }
}
