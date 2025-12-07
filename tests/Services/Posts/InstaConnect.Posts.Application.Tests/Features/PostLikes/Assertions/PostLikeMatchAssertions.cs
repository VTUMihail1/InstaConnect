namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Response.Id == postLike.Id.Id.Id &&
                                    p.Response.UserId == postLike.Id.UserId.Id);
    }

    public static void ShouldSatisfy(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.Response.Id == postLike.Id.Id.Id &&
                                    p.Response.User.Id == user.Id.Id &&
                                    p.Response.User.Name == user.Name.Value &&
                                    (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                    p.Response.CreatedAtUtc == postLike.CreatedAtUtc);
    }

    public static void ShouldSatisfy(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(pp => pp.Response.Entities.All(p => p.Id == postLike.Id.Id.Id &&
                                                 p.User.Id == user.Id.Id &&
                                                 p.User.Name == user.Name.Value &&
                                                 (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.User.ProfileImageUrl) &&
                                                 p.CreatedAtUtc == postLike.CreatedAtUtc) &&
                                     pp.Response.Page == request.Page &&
                                     pp.Response.PageSize == request.PageSize &&
                                     pp.Response.TotalCount == pp.Response.Entities.Count &&
                                     pp.Response.HasPreviousPage == pp.Response.Page > 1 &&
                                     pp.Response.HasNextPage == pp.Response.Page * pp.Response.PageSize < pp.Response.TotalCount);
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.Id.Id.Id == request.Id &&
                                    p.Id.UserId.Id == request.UserId);
    }
}
