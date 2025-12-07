namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMatcher
{
    public static GetAllPostCommentLikesQuery IsGetAllPostCommentLikesQuery(GetAllPostCommentLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQuery>(p => p.Filter.CommentId.Id.Id == request.Id &&
                                                            p.Filter.CommentId.CommentId == request.CommentId &&
                                                            p.Filter.UserName.Value == request.UserName &&
                                                            p.Pagination.Page == request.Page &&
                                                            p.Pagination.PageSize == request.PageSize &&
                                                            p.Sorting.Order == request.SortOrder &&
                                                            p.Sorting.Property == request.SortProperty &&
                                                            p.Include!.Properties.All(a => a == PostCommentLikeIncludeProperty.User));
    }

    public static GetPostCommentLikeByIdQuery IsGetPostCommentLikeByIdQuery(GetPostCommentLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQuery>(p => p.Id.CommentId.Id.Id == request.Id &&
                                                            p.Id.CommentId.CommentId == request.CommentId &&
                                                            p.Id.UserId.Id == request.UserId &&
                                                            p.Include!.Properties.All(a => a == PostCommentLikeIncludeProperty.User));
    }

    public static AddPostCommentLikeCommand IsAddPostCommentLikeCommand(AddPostCommentLikeCommandRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommand>(p => p.CommentId.Id.Id == request.Id &&
                                                          p.CommentId.CommentId == request.CommentId &&
                                                          p.UserId.Id == request.UserId);
    }

    public static DeletePostCommentLikeCommand IsDeletePostCommentLikeCommand(DeletePostCommentLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommand>(p => p.Id.CommentId.Id.Id == request.Id &&
                                                             p.Id.CommentId.CommentId == request.CommentId &&
                                                             p.Id.UserId.Id == request.UserId);
    }
}
