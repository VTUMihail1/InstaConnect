using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
public static class UserExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this Func<Task> action,
        string id)
    {
        await action.ShouldThrowAsync<UserNotFoundException>(
            UserExceptionErrorMessages.GetNotFoundMessage(id));
    }
}
