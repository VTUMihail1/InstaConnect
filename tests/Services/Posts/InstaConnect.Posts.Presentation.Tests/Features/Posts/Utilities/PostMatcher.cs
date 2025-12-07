namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostMatcher
{
    public static GetAllPostsQueryRequest IsGetAllPostsQueryRequest(GetAllPostsApiRequest request)
    {
        return Matcher.Is<GetAllPostsQueryRequest>(p => p.UserId == request.UserId &&
                                                        p.UserName == request.UserName &&
                                                        p.Title == request.Title &&
                                                        p.Page == request.Page &&
                                                        p.PageSize == request.PageSize &&
                                                        p.SortOrder == request.SortOrder &&
                                                        p.SortProperty == request.SortProperty);
    }

    public static GetPostByIdQueryRequest IsGetPostByIdQueryRequest(GetPostByIdApiRequest request)
    {
        return Matcher.Is<GetPostByIdQueryRequest>(p => p.Id == request.Id);
    }

    public static AddPostCommandRequest IsAddPostCommandRequest(AddPostApiRequest request)
    {
        return Matcher.Is<AddPostCommandRequest>(p => p.Title == request.Body.Title &&
                                                      p.Content == request.Body.Content &&
                                                      p.UserId == request.UserId);
    }

    public static UpdatePostCommandRequest IsUpdatePostCommandRequest(UpdatePostApiRequest request)
    {
        return Matcher.Is<UpdatePostCommandRequest>(p => p.Id == request.Id &&
                                                         p.Title == request.Body.Title &&
                                                         p.Content == request.Body.Content &&
                                                         p.UserId == request.UserId);
    }

    public static DeletePostCommandRequest IsDeletePostCommandRequest(DeletePostApiRequest request)
    {
        return Matcher.Is<DeletePostCommandRequest>(p => p.Id == request.Id &&
                                                         p.UserId == request.UserId);
    }
}
