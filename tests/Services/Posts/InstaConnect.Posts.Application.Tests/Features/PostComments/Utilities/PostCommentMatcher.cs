namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMatcher
{
    public static GetAllPostCommentsQuery IsGetAllPostCommentsQuery(GetAllPostCommentsQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentsQuery>(p => p.Matches(request));
    }

    public static GetPostCommentByIdQuery IsGetPostCommentByIdQuery(GetPostCommentByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentByIdQuery>(p => p.Matches(request));
    }

    public static AddPostCommentCommand IsAddPostCommentCommand(AddPostCommentCommandRequest request)
    {
        return Matcher.Is<AddPostCommentCommand>(p => p.Matches(request));
    }

    public static UpdatePostCommentCommand IsUpdatePostCommentCommand(UpdatePostCommentCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommentCommand>(p => p.Matches(request));
    }

    public static DeletePostCommentCommand IsDeletePostCommentCommand(DeletePostCommentCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentCommand>(p => p.Matches(request));
    }
}
