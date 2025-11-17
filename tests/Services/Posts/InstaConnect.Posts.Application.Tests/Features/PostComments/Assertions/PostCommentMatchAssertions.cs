using InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Id == postComment.Id &&
                                    p.CommentId == postComment.CommentId &&
                                    p.CreatedAt == postComment.CreatedAtUtc &&
                                    p.UpdatedAt == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this UpdatePostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Id == postComment.Id &&
                                    p.CommentId == postComment.CommentId &&
                                    p.CreatedAt == postComment.CreatedAtUtc &&
                                    p.UpdatedAt == postComment.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this GetPostCommentByIdQueryResponse response, PostComment postComment, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == postComment.Id &&
                                    p.Data.CommentId == postComment.CommentId &&
                                    p.Data.Content == postComment.Content &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostCommentsQueryResponse response, PostComment postComment, User user, GetAllPostCommentsQueryRequest request)
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

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.Id == request.Id &&
                                       p.UserId == request.UserId &&
                                       p.Content == request.Content);
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.Id == request.Id &&
                                       p.CommentId == request.CommentId &&
                                       p.UserId == request.UserId &&
                                       p.Content == request.Content);
    }
}
