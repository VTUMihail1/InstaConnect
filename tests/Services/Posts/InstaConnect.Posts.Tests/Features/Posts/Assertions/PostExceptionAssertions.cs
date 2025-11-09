using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
    public static async Task ShouldThrowPostNotFoundExceptionAsync(
        this Func<Task> action,
        string id)
    {
        await action.ShouldThrowAsync<PostNotFoundException>(
            PostExceptionErrorMessages.GetNotFoundMessage(id));
    }

    public static async Task ShouldThrowPostForbiddenExceptionAsync(
        this Func<Task> action,
        string id,
        string userId)
    {
        await action.ShouldThrowAsync<PostForbiddenException>(
            PostExceptionErrorMessages.GetForbiddenMessage(id, userId));
    }
}
