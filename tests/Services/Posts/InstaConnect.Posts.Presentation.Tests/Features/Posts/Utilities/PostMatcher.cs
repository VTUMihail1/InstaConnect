namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMatcher
{
    public static GetAllPostsQueryRequest IsGetAllPostsQueryRequest(GetAllPostsApiRequest request)
    {
        return Matcher.Is<GetAllPostsQueryRequest>(p => p.Matches(request));
    }

    public static GetAllPostsForUserQueryRequest IsGetAllPostsForUserQueryRequest(GetAllPostsForUserApiRequest request)
    {
        return Matcher.Is<GetAllPostsForUserQueryRequest>(p => p.Matches(request));
    }

    public static GetPostByIdQueryRequest IsGetPostByIdQueryRequest(GetPostByIdApiRequest request)
    {
        return Matcher.Is<GetPostByIdQueryRequest>(p => p.Matches(request));
    }

    public static AddPostCommandRequest IsAddPostCommandRequest(AddPostApiRequest request)
    {
        return Matcher.Is<AddPostCommandRequest>(p => p.Matches(request));
    }

    public static UpdatePostCommandRequest IsUpdatePostCommandRequest(UpdatePostApiRequest request)
    {
        return Matcher.Is<UpdatePostCommandRequest>(p => p.Matches(request));
    }

    public static DeletePostCommandRequest IsDeletePostCommandRequest(DeletePostApiRequest request)
    {
        return Matcher.Is<DeletePostCommandRequest>(p => p.Matches(request));
    }
}
