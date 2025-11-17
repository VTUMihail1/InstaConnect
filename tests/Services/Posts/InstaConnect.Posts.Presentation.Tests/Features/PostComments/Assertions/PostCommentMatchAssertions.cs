using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Id == postComment.Id &&
                                    p.CommentId == postComment.CommentId &&
                                    p.CreatedAt == postComment.CreatedAtUtc &&
                                    p.UpdatedAt == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this UpdatePostCommentApiResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Id == postComment.Id &&
                                    p.CommentId == postComment.CommentId &&
                                    p.CreatedAt == postComment.CreatedAtUtc &&
                                    p.UpdatedAt == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this GetPostCommentByIdApiResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == postComment.Id &&
                                    p.Data.CommentId == postComment.CommentId &&
                                    p.Data.Content == postComment.Content &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostCommentsApiResponse response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldSatisfy(pp => pp.Data.All(p => p.Id == postComment.Id &&
                                                      p.CommentId == postComment.CommentId &&
                                                      p.Content == postComment.Content &&
                                                      p.User.Id == user.Id &&
                                                      p.User.Name == user.Name &&
                                                      p.User.ProfileImage == user.ProfileImage) &&
                                     pp.Page == request.Pagination.Page &&
                                     pp.PageSize == request.Pagination.PageSize &&
                                     pp.TotalCount == pp.Data.Count &&
                                     pp.HasPreviousPage == pp.Page > 1 &&
                                     pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this ActionResult<AddPostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == postComment.Id &&
                                    p.CommentId == postComment.CommentId &&
                                    p.CreatedAt == postComment.CreatedAtUtc &&
                                    p.UpdatedAt == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostCommentApiResponse> response, PostComment postComment)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == postComment.Id &&
                                    p.CommentId == postComment.CommentId &&
                                    p.CreatedAt == postComment.CreatedAtUtc &&
                                    p.UpdatedAt == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostCommentByIdApiResponse> response, PostComment postComment, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Data.Id == postComment.Id &&
                                                     p.Data.CommentId == postComment.CommentId &&
                                                     p.Data.Content == postComment.Content &&
                                                     p.Data.User.Id == user.Id &&
                                                     p.Data.User.Name == user.Name &&
                                                     p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostCommentsApiResponse> response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Data.All(p => p.Id == postComment.Id &&
                                                                       p.CommentId == postComment.CommentId &&
                                                                       p.Content == postComment.Content &&
                                                                       p.User.Id == user.Id &&
                                                                       p.User.Name == user.Name &&
                                                                       p.User.ProfileImage == user.ProfileImage) &&
                                                pp.Page == request.Pagination.Page &&
                                                pp.PageSize == request.Pagination.PageSize &&
                                                pp.TotalCount == pp.Data.Count &&
                                                pp.HasPreviousPage == pp.Page > 1 &&
                                                pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Id == request.Id &&
                                       p.UserId == request.UserId &&
                                       p.Content == request.Body.Content);
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Id == request.Id &&
                                       p.CommentId == request.CommentId &&
                                       p.UserId == request.UserId &&
                                       p.Content == request.Body.Content);
    }
}
