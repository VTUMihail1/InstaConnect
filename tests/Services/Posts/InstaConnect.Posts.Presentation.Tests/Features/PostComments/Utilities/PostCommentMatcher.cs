namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQueryRequest IsGetAllPostCommentsQueryRequest(GetAllPostCommentsApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQueryRequest>(p => p.Filter.Id == request.Filter.Id &&
                                                               p.Filter.UserId == request.Filter.UserId &&
                                                               p.Filter.UserName == request.Filter.UserName &&
                                                               p.Pagination.Page == request.Pagination.Page &&
                                                               p.Pagination.PageSize == request.Pagination.PageSize &&
                                                               p.Sorting.Order == request.Sorting.Order &&
                                                               p.Sorting.Property == request.Sorting.Property);
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
