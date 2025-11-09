namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQueryRequest IsGetAllPostLikesQueryRequest(GetAllPostLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostLikesQueryRequest>(p => p.Filter.Id == request.Filter.Id &&
                                                            p.Filter.UserName == request.Filter.UserName &&
                                                            p.Pagination.Page == request.Pagination.Page &&
                                                            p.Pagination.PageSize == request.Pagination.PageSize &&
                                                            p.Sorting.Order == request.Sorting.Order &&
                                                            p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostLikeByIdQueryRequest IsGetPostLikeByIdQueryRequest(GetPostLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQueryRequest>(p => p.Id == request.Id &&
                                                            p.UserId == request.UserId);
    }

    public static AddPostLikeCommandRequest IsAddPostLikeCommandRequest(AddPostLikeApiRequest request)
    {
        return Matcher.Is<AddPostLikeCommandRequest>(p => p.Id == request.Id &&
                                                          p.UserId == request.UserId);
    }

    public static DeletePostLikeCommandRequest IsDeletePostLikeCommandRequest(DeletePostLikeApiRequest request)
    {
        return Matcher.Is<DeletePostLikeCommandRequest>(p => p.Id == request.Id &&
                                                             p.UserId == request.UserId);
    }
}
