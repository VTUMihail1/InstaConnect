using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Exceptions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;

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
