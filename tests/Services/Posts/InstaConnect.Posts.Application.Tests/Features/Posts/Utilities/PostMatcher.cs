namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMatcher
{
    public static GetAllPostsQuery IsGetAllPostsQuery(GetAllPostsQueryRequest request, CommonIncludeQuery<PostIncludeProperty> include)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.Matches(request, include));
    }

    public static GetPostByIdQuery IsGetPostByIdQuery(GetPostByIdQueryRequest request, CommonIncludeQuery<PostIncludeProperty> include)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.Matches(request, include));
    }

    public static AddPostCommand IsAddPostCommand(AddPostCommandRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.Matches(request));
    }

    public static UpdatePostCommand IsUpdatePostCommand(UpdatePostCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.Matches(request));
    }

    public static DeletePostCommand IsDeletePostCommand(DeletePostCommandRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.Matches(request));
    }
}
