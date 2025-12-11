namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMatcher
{
    public static GetAllPostCommentLikesQuery IsGetAllPostCommentLikesQuery(GetAllPostCommentLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQuery>(p => p.Matches(request));
    }

    public static GetPostCommentLikeByIdQuery IsGetPostCommentLikeByIdQuery(GetPostCommentLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQuery>(p => p.Matches(request));
    }

    public static AddPostCommentLikeCommand IsAddPostCommentLikeCommand(AddPostCommentLikeCommandRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommand>(p => p.Matches(request));
    }

    public static DeletePostCommentLikeCommand IsDeletePostCommentLikeCommand(DeletePostCommentLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommand>(p => p.Matches(request));
    }
}
