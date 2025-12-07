namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        response.ShouldSatisfy(p => p.Response.Id == postCommentLike.Id.CommentId.Id.Id &&
                                    p.Response.CommentId == postCommentLike.Id.CommentId.CommentId &&
                                    p.Response.UserId == postCommentLike.Id.UserId.Id);
    }

    public static void ShouldSatisfy(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldSatisfy(p => p.Response.Id == postCommentLike.Id.CommentId.Id.Id &&
                                    p.Response.CommentId == postCommentLike.Id.CommentId.CommentId &&
                                    p.Response.User.Id == user.Id.Id &&
                                    p.Response.User.Name == user.Name.Value &&
                                    (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                    p.Response.CreatedAtUtc == postCommentLike.CreatedAtUtc);
    }

    public static void ShouldSatisfy(this GetAllPostCommentLikesApiResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldSatisfy(pp => pp.Response.Entities.All(p => p.Id == postCommentLike.Id.CommentId.Id.Id &&
                                                 p.CommentId == postCommentLike.Id.CommentId.CommentId &&
                                                 p.User.Id == user.Id.Id &&
                                                 p.User.Name == user.Name.Value &&
                                                 (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.User.ProfileImageUrl) &&
                                                 p.CreatedAtUtc == postCommentLike.CreatedAtUtc) &&
                                     pp.Response.Page == request.Page &&
                                     pp.Response.PageSize == request.PageSize &&
                                     pp.Response.TotalCount == pp.Response.Entities.Count &&
                                     pp.Response.HasPreviousPage == pp.Response.Page > 1 &&
                                     pp.Response.HasNextPage == pp.Response.Page * pp.Response.PageSize < pp.Response.TotalCount);
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentLikeApiResponse> response, PostCommentLike postCommentLike)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == postCommentLike.Id.CommentId.Id.Id &&
                                                     p.Response.CommentId == postCommentLike.Id.CommentId.CommentId &&
                                                     p.Response.UserId == postCommentLike.Id.UserId.Id);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentLikeByIdApiResponse> response, PostCommentLike postCommentLike, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == postCommentLike.Id.CommentId.Id.Id &&
                                    p.Response.CommentId == postCommentLike.Id.CommentId.CommentId &&
                                    p.Response.User.Id == user.Id.Id &&
                                    p.Response.User.Name == user.Name.Value &&
                                    (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                    p.Response.CreatedAtUtc == postCommentLike.CreatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentLikesApiResponse> response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Response.Entities.All(p => p.Id == postCommentLike.Id.CommentId.Id.Id &&
                                                 p.CommentId == postCommentLike.Id.CommentId.CommentId &&
                                                 p.User.Id == user.Id.Id &&
                                                 p.User.Name == user.Name.Value &&
                                                 (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.User.ProfileImageUrl) &&
                                                 p.CreatedAtUtc == postCommentLike.CreatedAtUtc) &&
                                     pp.Response.Page == request.Page &&
                                     pp.Response.PageSize == request.PageSize &&
                                     pp.Response.TotalCount == pp.Response.Entities.Count &&
                                     pp.Response.HasPreviousPage == pp.Response.Page > 1 &&
                                     pp.Response.HasNextPage == pp.Response.Page * pp.Response.PageSize < pp.Response.TotalCount);
    }

    public static void ShouldSatisfy(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        postCommentLike.ShouldSatisfy(p => p.Id.CommentId.Id.Id == request.Id &&
                                           p.Id.CommentId.CommentId == request.CommentId &&
                                           p.Id.UserId.Id == request.UserId);
    }
}
