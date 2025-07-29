using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "User(id: {0}) does not exist";
        var result = Format.FormatInvariantCulture(id);

        return result;
    }

    public static string GetAlreadyExistsMessage(string id)
    {
        const string Format = "User(id: {0}) already exists";
        var result = Format.FormatInvariantCulture(id);

        return result;
    }
}
