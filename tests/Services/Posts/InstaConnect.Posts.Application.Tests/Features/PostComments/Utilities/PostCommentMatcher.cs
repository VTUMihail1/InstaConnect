namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQuery IsGetAllPostCommentsQuery(GetAllPostCommentsQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQuery>(p => p.Filter.Id.Id == request.Id &&
                                                        p.Filter.UserId.Id == request.UserId &&
                                                        p.Filter.UserName.Value == request.UserName &&
                                                        p.Pagination.Page == request.Page &&
                                                        p.Pagination.PageSize == request.PageSize &&
                                                        p.Sorting.Order == request.SortOrder &&
                                                        p.Sorting.Property == request.SortProperty &&
                                                        p.Include!.Properties.All(a => a == PostCommentIncludeProperty.User));
    }

    public static GetPostCommentByIdQuery IsGetPostCommentByIdQuery(GetPostCommentByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQuery>(p => p.Id.Id.Id == request.Id &&
                                                        p.Id.CommentId == request.CommentId &&
                                                        p.Include!.Properties.All(a => a == PostCommentIncludeProperty.User));
    }

    public static AddPostCommentCommand IsAddPostCommentCommand(AddPostCommentCommandRequest request)
    {
        return Matcher.Is<AddPostCommentCommand>(p => p.Id.Id == request.Id &&
                                                      p.Content == request.Content &&
                                                      p.UserId.Id == request.UserId);
    }

    public static UpdatePostCommentCommand IsUpdatePostCommentCommand(UpdatePostCommentCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommand>(p => p.Id.Id.Id == request.Id &&
                                                         p.Id.CommentId == request.CommentId &&
                                                         p.Content == request.Content &&
                                                         p.UserId.Id == request.UserId);
    }

    public static DeletePostCommentCommand IsDeletePostCommentCommand(DeletePostCommentCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentCommand>(p => p.Id.Id.Id == request.Id &&
                                                         p.Id.CommentId == request.CommentId &&
                                                         p.UserId.Id == request.UserId);
    }
}
