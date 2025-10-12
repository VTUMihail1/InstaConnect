using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "User(id: {0}) does not exist";
        var result = Format.FormatCurrentCulture(id);

        return result;
    }

    public static string GetAlreadyExistsMessage(string id)
    {
        const string Format = "User(id: {0}) already exists";
        var result = Format.FormatCurrentCulture(id);

        return result;
    }

    public static string GetNameAlreadyExistsMessage(string name)
    {
        const string Format = "User(name: {0}) already exists";
        var result = Format.FormatCurrentCulture(name);

        return result;
    }

    public static string GetEmailAlreadyExistsMessage(string email)
    {
        const string Format = "User(email: {0}) already exists";
        var result = Format.FormatCurrentCulture(email);

        return result;
    }
}
