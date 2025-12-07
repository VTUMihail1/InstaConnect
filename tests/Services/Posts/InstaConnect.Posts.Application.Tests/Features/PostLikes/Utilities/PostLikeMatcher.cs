namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQuery IsGetAllPostLikesQuery(GetAllPostLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostLikesQuery>(p => p.Filter.Id.Id == request.Id &&
                                                     p.Filter.UserName.Value == request.UserName &&
                                                     p.Pagination.Page == request.Page &&
                                                     p.Pagination.PageSize == request.PageSize &&
                                                     p.Sorting.Order == request.SortOrder &&
                                                     p.Sorting.Property == request.SortProperty &&
                                                     p.Include!.Properties.All(a => a == PostLikeIncludeProperty.User));
    }

    public static GetPostLikeByIdQuery IsGetPostLikeByIdQuery(GetPostLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQuery>(p => p.Id.Id.Id == request.Id &&
                                                     p.Id.UserId.Id == request.UserId &&
                                                     p.Include!.Properties.All(a => a == PostLikeIncludeProperty.User));
    }

    public static AddPostLikeCommand IsAddPostLikeCommand(AddPostLikeCommandRequest request)
    {
        return Matcher.Is<AddPostLikeCommand>(p => p.Id.Id == request.Id &&
                                                   p.UserId.Id == request.UserId);
    }

    public static DeletePostLikeCommand IsDeletePostLikeCommand(DeletePostLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostLikeCommand>(p => p.Id.Id.Id == request.Id &&
                                                      p.Id.UserId.Id == request.UserId);
    }
}
