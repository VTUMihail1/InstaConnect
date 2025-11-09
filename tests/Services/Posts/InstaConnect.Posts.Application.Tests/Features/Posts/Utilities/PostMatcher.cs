namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMatcher
{
    public static GetAllPostsQuery IsGetAllPostsQuery(GetAllPostsQueryRequest request)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.Filter.UserId == request.Filter.UserId &&
                                                 p.Filter.UserName == request.Filter.UserName &&
                                                 p.Filter.Title == request.Filter.Title &&
                                                 p.Pagination.Page == request.Pagination.Page &&
                                                 p.Pagination.PageSize == request.Pagination.PageSize &&
                                                 p.Sorting.Order == request.Sorting.Order &&
                                                 p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostByIdQuery IsGetPostByIdQuery(GetPostByIdQueryRequest request)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.Id == request.Id);
    }

    public static AddPostCommand IsAddPostCommand(AddPostCommandRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.Title == request.Title &&
                                               p.Content == request.Content &&
                                               p.UserId == request.UserId);
    }

    public static UpdatePostCommand IsUpdatePostCommand(UpdatePostCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.Id == request.Id &&
                                                  p.Title == request.Title &&
                                                  p.Content == request.Content &&
                                                  p.UserId == request.UserId);
    }

    public static DeletePostCommand IsDeletePostCommand(DeletePostCommandRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.Id == request.Id &&
                                                  p.UserId == request.UserId);
    }
}
