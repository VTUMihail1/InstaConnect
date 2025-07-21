using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "User(id: {0}) with that id does not exist";
        var result = Format.FormatInvariant(id);

        return result;
    }
}
