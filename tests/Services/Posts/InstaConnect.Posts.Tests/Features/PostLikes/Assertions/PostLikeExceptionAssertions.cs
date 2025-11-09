using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
    public static async Task ShouldThrowPostLikeNotFoundExceptionAsync(
        this Func<Task> action,
        string id,
        string userId)
    {
        await action.ShouldThrowAsync<PostLikeNotFoundException>(
            PostLikeExceptionErrorMessages.GetNotFoundMessage(id, userId));
    }

    public static async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync(
        this Func<Task> action,
        string id,
        string userId)
    {
        await action.ShouldThrowAsync<PostLikeAlreadyExistsException>(
            PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id, userId));
    }
}
