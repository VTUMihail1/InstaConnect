namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQuery IsGetAllPostLikesQuery(GetAllPostLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostLikesQuery>(p => p.Filter.Id == request.Filter.Id &&
                                                        p.Filter.UserName == request.Filter.UserName &&
                                                        p.Pagination.Page == request.Pagination.Page &&
                                                        p.Pagination.PageSize == request.Pagination.PageSize &&
                                                        p.Sorting.Order == request.Sorting.Order &&
                                                        p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostLikeByIdQuery IsGetPostLikeByIdQuery(GetPostLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQuery>(p => p.Id == request.Id &&
                                                     p.UserId == request.UserId);
    }

    public static AddPostLikeCommand IsAddPostLikeCommand(AddPostLikeCommandRequest request)
    {
        return Matcher.Is<AddPostLikeCommand>(p => p.Id == request.Id &&
                                                   p.UserId == request.UserId);
    }

    public static DeletePostLikeCommand IsDeletePostLikeCommand(DeletePostLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostLikeCommand>(p => p.Id == request.Id &&
                                                      p.UserId == request.UserId);
    }
}
