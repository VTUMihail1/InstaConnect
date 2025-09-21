using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

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
