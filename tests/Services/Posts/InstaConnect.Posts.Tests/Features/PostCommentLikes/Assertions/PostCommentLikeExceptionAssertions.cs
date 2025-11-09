using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
    public static async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
        this Func<Task> action,
        string id,
        string commentId,
        string userId)
    {
        await action.ShouldThrowAsync<PostCommentLikeNotFoundException>(
            PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(id, commentId, userId));
    }

    public static async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
        this Func<Task> action,
        string id,
        string commentId,
        string userId)
    {
        await action.ShouldThrowAsync<PostCommentLikeAlreadyExistsException>(
            PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(id, commentId, userId));
    }
}
