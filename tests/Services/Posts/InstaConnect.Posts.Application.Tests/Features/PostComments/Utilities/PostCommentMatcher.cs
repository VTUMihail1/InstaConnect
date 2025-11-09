namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQuery IsGetAllPostCommentsQuery(GetAllPostCommentsQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQuery>(p => p.Filter.Id == request.Filter.Id &&
                                                        p.Filter.UserId == request.Filter.UserId &&
                                                        p.Filter.UserName == request.Filter.UserName &&
                                                        p.Pagination.Page == request.Pagination.Page &&
                                                        p.Pagination.PageSize == request.Pagination.PageSize &&
                                                        p.Sorting.Order == request.Sorting.Order &&
                                                        p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostCommentByIdQuery IsGetPostCommentByIdQuery(GetPostCommentByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQuery>(p => p.Id == request.Id &&
                                                        p.CommentId == request.CommentId);
    }

    public static AddPostCommentCommand IsAddPostCommentCommand(AddPostCommentCommandRequest request)
    {
        return Matcher.Is<AddPostCommentCommand>(p => p.Id == request.Id &&
                                                      p.Content == request.Content &&
                                                      p.UserId == request.UserId);
    }

    public static UpdatePostCommentCommand IsUpdatePostCommentCommand(UpdatePostCommentCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommand>(p => p.Id == request.Id &&
                                                         p.CommentId == request.CommentId &&
                                                         p.Content == request.Content &&
                                                         p.UserId == request.UserId);
    }

    public static DeletePostCommentCommand IsDeletePostCommentCommand(DeletePostCommentCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentCommand>(p => p.Id == request.Id &&
                                                         p.CommentId == request.CommentId &&
                                                         p.UserId == request.UserId);
    }
}
