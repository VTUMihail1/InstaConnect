namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMatcher
{
    public static GetAllPostsQuery IsGetAllPostsQuery(GetAllPostsQueryRequest request)
    {
        return Matcher.Is<GetAllPostsQuery>(p => p.Filter.UserId.Id == request.UserId &&
                                                 p.Filter.UserName.Value == request.UserName &&
                                                 p.Filter.Title == request.Title &&
                                                 p.Pagination.Page == request.Page &&
                                                 p.Pagination.PageSize == request.PageSize &&
                                                 p.Sorting.Order == request.SortOrder &&
                                                 p.Sorting.Property == request.SortProperty &&
                                                 p.Include!.Properties.All(a => a == PostIncludeProperty.User));
    }

    public static GetPostByIdQuery IsGetPostByIdQuery(GetPostByIdQueryRequest request)
    {
        return Matcher.Is<GetPostByIdQuery>(p => p.Id.Id == request.Id &&
                                                 p.Include!.Properties.All(a => a == PostIncludeProperty.User));
    }

    public static AddPostCommand IsAddPostCommand(AddPostCommandRequest request)
    {
        return Matcher.Is<AddPostCommand>(p => p.Title == request.Title &&
                                               p.Content == request.Content &&
                                               p.UserId.Id == request.UserId);
    }

    public static UpdatePostCommand IsUpdatePostCommand(UpdatePostCommandRequest request)
    {
        return Matcher.Is<UpdatePostCommand>(p => p.Id.Id == request.Id &&
                                                  p.Title == request.Title &&
                                                  p.Content == request.Content &&
                                                  p.UserId.Id == request.UserId);
    }

    public static DeletePostCommand IsDeletePostCommand(DeletePostCommandRequest request)
    {
        return Matcher.Is<DeletePostCommand>(p => p.Id.Id == request.Id &&
                                                  p.UserId.Id == request.UserId);
    }
}
