namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMatcher
{
    public static GetAllPostCommentLikesQueryRequest IsGetAllPostCommentLikesQueryRequest(GetAllPostCommentLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQueryRequest>(p => p.Matches(request));
    }

    public static GetAllPostCommentLikesForUserQueryRequest IsGetAllPostCommentLikesForUserQueryRequest(GetAllPostCommentLikesForUserApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesForUserQueryRequest>(p => p.Matches(request));
    }

    public static GetPostCommentLikeByIdQueryRequest IsGetPostCommentLikeByIdQueryRequest(GetPostCommentLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQueryRequest>(p => p.Matches(request));
    }

    public static AddPostCommentLikeCommandRequest IsAddPostCommentLikeCommandRequest(AddPostCommentLikeApiRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommandRequest>(p => p.Matches(request));
    }

    public static DeletePostCommentLikeCommandRequest IsDeletePostCommentLikeCommandRequest(DeletePostCommentLikeApiRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommandRequest>(p => p.Matches(request));
    }
}
