namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQueryRequest IsGetAllPostCommentsQueryRequest(GetAllPostCommentsApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQueryRequest>(p => p.Matches(request));
    }

    public static GetPostCommentByIdQueryRequest IsGetPostCommentByIdQueryRequest(GetPostCommentByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQueryRequest>(p => p.Matches(request));
    }

    public static AddPostCommentCommandRequest IsAddPostCommentCommandRequest(AddPostCommentApiRequest request)
    {
        return Matcher.Is<AddPostCommentCommandRequest>(p => p.Matches(request));
    }

    public static UpdatePostCommentCommandRequest IsUpdatePostCommentCommandRequest(UpdatePostCommentApiRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommandRequest>(p => p.Matches(request));
    }

    public static DeletePostCommentCommandRequest IsDeletePostCommentCommandRequest(DeletePostCommentApiRequest request)
    {
        return Matcher.Is<DeletePostCommentCommandRequest>(p => p.Matches(request));
    }
}
