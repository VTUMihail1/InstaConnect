namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMatcher
{
    public static GetAllPostCommentLikesQueryRequest IsGetAllPostCommentLikesQueryRequest(GetAllPostCommentLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQueryRequest>(p => p.Id == request.Id &&
                                                                   p.CommentId == request.CommentId &&
                                                                   p.UserName == request.UserName &&
                                                                   p.Page == request.Page &&
                                                                   p.PageSize == request.PageSize &&
                                                                   p.SortOrder == request.SortOrder &&
                                                                   p.SortProperty == request.SortProperty);
    }

    public static GetPostCommentLikeByIdQueryRequest IsGetPostCommentLikeByIdQueryRequest(GetPostCommentLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQueryRequest>(p => p.Id == request.Id &&
                                                                   p.CommentId == request.CommentId &&
                                                                   p.UserId == request.UserId);
    }

    public static AddPostCommentLikeCommandRequest IsAddPostCommentLikeCommandRequest(AddPostCommentLikeApiRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommandRequest>(p => p.Id == request.Id &&
                                                                 p.CommentId == request.CommentId &&
                                                                 p.UserId == request.UserId);
    }

    public static DeletePostCommentLikeCommandRequest IsDeletePostCommentLikeCommandRequest(DeletePostCommentLikeApiRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommandRequest>(p => p.Id == request.Id &&
                                                                    p.CommentId == request.CommentId &&
                                                                    p.UserId == request.UserId);
    }
}
