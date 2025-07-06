using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Domain.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

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
