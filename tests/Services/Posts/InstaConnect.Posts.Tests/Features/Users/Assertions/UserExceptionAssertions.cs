using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Tests.Features.Users.Assertions;
public static class UserExceptionAssertions
{
    public static async Task ShouldThrowUserNotFoundExceptionAsync(
        this Func<Task> action,
        string id)
    {
        await action.ShouldThrowAsync<UserNotFoundException>(
            UserExceptionErrorMessages.GetNotFoundMessage(id));
    }

    public static async Task ShouldThrowUserAlreadyExistsExceptionAsync(
        this Func<Task> action,
        string id)
    {
        await action.ShouldThrowAsync<UserAlreadyExistsException>(
            UserExceptionErrorMessages.GetAlreadyExistsMessage(id));
    }

    public static async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
        this Func<Task> action,
        string name)
    {
        await action.ShouldThrowAsync<UserNameAlreadyExistsException>(
            UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name));
    }

    public static async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
        this Func<Task> action,
        string email)
    {
        await action.ShouldThrowAsync<UserEmailAlreadyExistsException>(
            UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email));
    }
}
