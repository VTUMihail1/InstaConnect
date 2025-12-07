namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Response.Id == postComment.Id.Id.Id &&
                                    p.Response.CommentId == postComment.Id.CommentId);
    }

    public static void ShouldSatisfy(this UpdatePostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Response.Id == postComment.Id.Id.Id &&
                                    p.Response.CommentId == postComment.Id.CommentId);
    }

    public static void ShouldSatisfy(this GetPostCommentByIdApiResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.Response.Id == postComment.Id.Id.Id &&
                                    p.Response.CommentId == postComment.Id.CommentId &&
                                    p.Response.User.Id == user.Id.Id &&
                                    p.Response.User.Name == user.Name.Value &&
                                    (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                    p.Response.CreatedAtUtc == postComment.CreatedAtUtc &&
                                    p.Response.UpdatedAtUtc == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this GetAllPostCommentsApiResponse response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldSatisfy(pp => pp.Response.Entities.All(p => p.Id == postComment.Id.Id.Id &&
                                                 p.CommentId == postComment.Id.CommentId &&
                                                 p.User.Id == user.Id.Id &&
                                                 p.User.Name == user.Name.Value &&
                                                 (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.User.ProfileImageUrl) &&
                                                 p.CreatedAtUtc == postComment.CreatedAtUtc &&
                                                 p.UpdatedAtUtc == postComment.UpdatedAtUtc) &&
                                     pp.Response.Page == request.Page &&
                                     pp.Response.PageSize == request.PageSize &&
                                     pp.Response.TotalCount == pp.Response.Entities.Count &&
                                     pp.Response.HasPreviousPage == pp.Response.Page > 1 &&
                                     pp.Response.HasNextPage == pp.Response.Page * pp.Response.PageSize < pp.Response.TotalCount);
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == postComment.Id.Id.Id &&
                                                     p.Response.CommentId == postComment.Id.CommentId);
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == postComment.Id.Id.Id &&
                                    p.Response.CommentId == postComment.Id.CommentId);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentByIdApiResponse> response, PostComment postComment, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == postComment.Id.Id.Id &&
                                    p.Response.CommentId == postComment.Id.CommentId &&
                                    p.Response.User.Id == user.Id.Id &&
                                    p.Response.User.Name == user.Name.Value &&
                                    (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                    p.Response.CreatedAtUtc == postComment.CreatedAtUtc &&
                                    p.Response.UpdatedAtUtc == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentsApiResponse> response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Response.Entities.All(p => p.Id == postComment.Id.Id.Id &&
                                                 p.CommentId == postComment.Id.CommentId &&
                                                 p.User.Id == user.Id.Id &&
                                                 p.User.Name == user.Name.Value &&
                                                 (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.User.ProfileImageUrl) &&
                                                 p.CreatedAtUtc == postComment.CreatedAtUtc &&
                                                 p.UpdatedAtUtc == postComment.UpdatedAtUtc) &&
                                     pp.Response.Page == request.Page &&
                                     pp.Response.PageSize == request.PageSize &&
                                     pp.Response.TotalCount == pp.Response.Entities.Count &&
                                     pp.Response.HasPreviousPage == pp.Response.Page > 1 &&
                                     pp.Response.HasNextPage == pp.Response.Page * pp.Response.PageSize < pp.Response.TotalCount);
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Id.Id.Id == request.Id &&
                                       p.UserId.Id == request.UserId &&
                                       p.Content == request.Body.Content);
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Id.Id.Id == request.Id &&
                                       p.Id.CommentId == request.CommentId &&
                                       p.UserId.Id == request.UserId &&
                                       p.Content == request.Body.Content);
    }
}
