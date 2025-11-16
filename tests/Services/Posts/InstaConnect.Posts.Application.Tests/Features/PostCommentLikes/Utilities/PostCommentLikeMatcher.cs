namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMatcher
{
    public static GetAllPostCommentLikesQuery IsGetAllPostCommentLikesQuery(GetAllPostCommentLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQuery>(p => p.Filter.CommentId == request.Filter.Id &&
                                                            p.Filter.CommentId == request.Filter.CommentId &&
                                                            p.Filter.UserName == request.Filter.UserName &&
                                                            p.Pagination.Page == request.Pagination.Page &&
                                                            p.Pagination.PageSize == request.Pagination.PageSize &&
                                                            p.Sorting.Order == request.Sorting.Order &&
                                                            p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostCommentLikeByIdQuery IsGetPostCommentLikeByIdQuery(GetPostCommentLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQuery>(p => p.Id == request.Id &&
                                                            p.CommentId == request.CommentId &&
                                                            p.UserId == request.UserId);
    }

    public static AddPostCommentLikeCommand IsAddPostCommentLikeCommand(AddPostCommentLikeCommandRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommand>(p => p.Id == request.Id &&
                                                          p.CommentId == request.CommentId &&
                                                          p.UserId == request.UserId);
    }

    public static DeletePostCommentLikeCommand IsDeletePostCommentLikeCommand(DeletePostCommentLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommand>(p => p.Id == request.Id &&
                                                             p.CommentId == request.CommentId &&
                                                             p.UserId == request.UserId);
    }
}
