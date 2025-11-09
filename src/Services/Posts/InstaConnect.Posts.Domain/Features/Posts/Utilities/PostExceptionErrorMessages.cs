using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.Posts.Utilities;

public static class PostExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "Post(id: {0}) with that id does not exist";
        var result = Format.FormatCurrentCulture(id);

        return result;
    }

    public static string GetForbiddenMessage(string id, string userId)
    {
        const string Format = "Post(id: {0}) is not owned by User(id: {1})";
        var result = Format.FormatCurrentCulture(id, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostSortProperty sortProperty)
    {
        const string Format = "PostSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostIncludeProperty> includeProperties)
    {
        const string Format = "PostIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
