using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

public static class PostLikeExceptionAssertions
{
    public static async Task ShouldThrowPostLikeNotFoundExceptionAsync(
        this Func<Task> action,
        string id,
        string likeId)
    {
        await action.ShouldThrowAsync<PostLikeNotFoundException>(
            PostLikeExceptionErrorMessages.GetNotFoundMessage(id, likeId));
    }

    public static async Task ShouldThrowPostLikeForbiddenExceptionAsync(
        this Func<Task> action,
        string id,
        string likeId,
        string userId)
    {
        await action.ShouldThrowAsync<PostLikeForbiddenException>(
            PostLikeExceptionErrorMessages.GetForbiddenMessage(id, likeId, userId));
    }
}
