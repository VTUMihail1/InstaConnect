using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Utilities;
public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "User(id: {0}) with that id does not exist";
        var result = Format.FormatInvariant(id);

        return result;
    }
}
