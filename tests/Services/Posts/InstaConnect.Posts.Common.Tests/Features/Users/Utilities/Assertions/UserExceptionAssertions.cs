using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
public static class UserExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(this Func<Task> action)
    {
        await action.ShouldThrowAsync<UserNotFoundException>();
    }

    public static async Task ShouldThrowUserForbiddenExceptionAsync(this Func<Task> action)
    {
        await action.ShouldThrowAsync<UserForbiddenException>();
    }
}
