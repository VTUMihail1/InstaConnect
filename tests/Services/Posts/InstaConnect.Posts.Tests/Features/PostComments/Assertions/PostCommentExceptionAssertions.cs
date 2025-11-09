using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
    public static async Task ShouldThrowPostCommentNotFoundExceptionAsync(
        this Func<Task> action,
        string id,
        string commentId)
    {
        await action.ShouldThrowAsync<PostCommentNotFoundException>(
            PostCommentExceptionErrorMessages.GetNotFoundMessage(id, commentId));
    }

    public static async Task ShouldThrowPostCommentForbiddenExceptionAsync(
        this Func<Task> action,
        string id,
        string commentId,
        string userId)
    {
        await action.ShouldThrowAsync<PostCommentForbiddenException>(
            PostCommentExceptionErrorMessages.GetForbiddenMessage(id, commentId, userId));
    }
}
