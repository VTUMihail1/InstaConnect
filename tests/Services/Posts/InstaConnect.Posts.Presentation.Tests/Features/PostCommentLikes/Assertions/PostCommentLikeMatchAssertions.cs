using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.Id == postCommentLike.Id &&
                                    p.CommentId == postCommentLike.CommentId &&
                                    p.UserId == postCommentLike.UserId &&
                                    p.CreatedAt == postCommentLike.CreatedAtUtc &&
                                    p.UpdatedAt == postCommentLike.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == postCommentLike.Id &&
                                    p.Data.CommentId == postCommentLike.CommentId &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostCommentLikesApiResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldSatisfy(pp => pp.Data.All(p => p.Id == postCommentLike.Id &&
                                                      p.CommentId == postCommentLike.CommentId &&
                                                      p.User.Id == user.Id &&
                                                      p.User.Name == user.Name &&
                                                      p.User.ProfileImage == user.ProfileImage) &&
                                     pp.Page == request.Pagination.Page &&
                                     pp.PageSize == request.Pagination.PageSize &&
                                     pp.TotalCount == pp.Data.Count &&
                                     pp.HasPreviousPage == pp.Page > 1 &&
                                     pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentLikeApiResponse> response, PostCommentLike postCommentLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == postCommentLike.Id &&
                                                     p.CommentId == postCommentLike.CommentId &&
                                                     p.UserId == postCommentLike.UserId &&
                                                     p.CreatedAt == postCommentLike.CreatedAtUtc &&
                                                     p.UpdatedAt == postCommentLike.UpdatedAt);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentLikeByIdApiResponse> response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Data.Id == postCommentLike.Id &&
                                                     p.Data.CommentId == postCommentLike.CommentId &&
                                                     p.Data.User.Id == user.Id &&
                                                     p.Data.User.Name == user.Name &&
                                                     p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentLikesApiResponse> response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Data.All(p => p.Id == postCommentLike.Id &&
                                                                       p.CommentId == postCommentLike.CommentId &&
                                                                       p.User.Id == user.Id &&
                                                                       p.User.Name == user.Name &&
                                                                       p.User.ProfileImage == user.ProfileImage) &&
                                                      pp.Page == request.Pagination.Page &&
                                                      pp.PageSize == request.Pagination.PageSize &&
                                                      pp.TotalCount == pp.Data.Count &&
                                                      pp.HasPreviousPage == pp.Page > 1 &&
                                                      pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Id == request.Id &&
                                           p.CommentId == postCommentLike.CommentId &&
                                           p.UserId == request.UserId);
    }
}
