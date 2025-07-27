using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Features.Posts.Utilities;

public static class PostExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "Post(id: {0}) with that id does not exist";
        var result = Format.FormatInvariantCulture(id);

        return result;
    }

    public static string GetForbiddenMessage(string id, string userId)
    {
        const string Format = "Post(id: {0}) is not owned by User(id: {1})";
        var result = Format.FormatInvariantCulture(id, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostSortProperty sortProperty)
    {
        const string Format = "PostSortProperty(type: {0}) is not supported";
        var result = Format.FormatInvariantCulture(sortProperty);

        return result;
    }
}
