using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;

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
