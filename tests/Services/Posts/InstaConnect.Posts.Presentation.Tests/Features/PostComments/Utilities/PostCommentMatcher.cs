namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQueryRequest IsGetAllPostCommentsQueryRequest(GetAllPostCommentsApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQueryRequest>(p => p.Id == request.Id &&
                                                               p.UserId == request.UserId &&
                                                               p.UserName == request.UserName &&
                                                               p.Page == request.Page &&
                                                               p.PageSize == request.PageSize &&
                                                               p.SortOrder == request.SortOrder &&
                                                               p.SortProperty == request.SortProperty);
    }

    public static GetPostCommentByIdQueryRequest IsGetPostCommentByIdQueryRequest(GetPostCommentByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQueryRequest>(p => p.Id == request.Id &&
                                                               p.CommentId == request.CommentId);
    }

    public static AddPostCommentCommandRequest IsAddPostCommentCommandRequest(AddPostCommentApiRequest request)
    {
        return Matcher.Is<AddPostCommentCommandRequest>(p => p.Id == request.Id &&
                                                             p.Content == request.Body.Content &&
                                                             p.UserId == request.UserId);
    }

    public static UpdatePostCommentCommandRequest IsUpdatePostCommentCommandRequest(UpdatePostCommentApiRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommandRequest>(p => p.Id == request.Id &&
                                                                p.CommentId == request.CommentId &&
                                                                p.Content == request.Body.Content &&
                                                                p.UserId == request.UserId);
    }

    public static DeletePostCommentCommandRequest IsDeletePostCommentCommandRequest(DeletePostCommentApiRequest request)
    {
        return Matcher.Is<DeletePostCommentCommandRequest>(p => p.Id == request.Id &&
                                                                p.CommentId == request.CommentId &&
                                                                p.UserId == request.UserId);
    }
}
