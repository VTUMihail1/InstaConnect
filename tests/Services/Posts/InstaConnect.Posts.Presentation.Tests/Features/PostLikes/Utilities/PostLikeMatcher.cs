namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQueryRequest IsGetAllPostLikesQueryRequest(GetAllPostLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostLikesQueryRequest>(p => p.Id == request.Id &&
                                                            p.UserName == request.UserName &&
                                                            p.Page == request.Page &&
                                                            p.PageSize == request.PageSize &&
                                                            p.SortOrder == request.SortOrder &&
                                                            p.SortProperty == request.SortProperty);
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
