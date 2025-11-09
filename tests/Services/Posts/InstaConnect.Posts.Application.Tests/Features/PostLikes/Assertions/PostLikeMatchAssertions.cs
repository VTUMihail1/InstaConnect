using InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        response.ShouldSatisfy(p => p.Id == postLike.Id &&
                                    p.UserId == postLike.UserId &&
                                    p.CreatedAt == postLike.CreatedAt &&
                                    p.UpdatedAt == postLike.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == postLike.Id &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        response.ShouldSatisfy(pp => pp.Data.All(p => p.Id == postLike.Id &&
                                                      p.User.Id == user.Id &&
                                                      p.User.Name == user.Name &&
                                                      p.User.ProfileImage == user.ProfileImage) &&
                                     pp.Page == request.Pagination.Page &&
                                     pp.PageSize == request.Pagination.PageSize &&
                                     pp.TotalCount == pp.Data.Count &&
                                     pp.HasPreviousPage == pp.Page > 1 &&
                                     pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        postLike.ShouldSatisfy(p => p.Id == request.Id &&
                                    p.UserId == request.UserId);
    }
}
