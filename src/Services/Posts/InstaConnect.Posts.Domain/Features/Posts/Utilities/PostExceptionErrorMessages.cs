using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.Posts.Utilities;

public static class PostExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostId id)
    {
        const string Format = "Post(id: {0}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetForbiddenMessage(PostId id, UserId userId)
    {
        const string Format = "Post(id: {0}) is not owned by User(id: {1})";

        return Format.FormatCurrentCulture(id.Id, userId.Id);
    }

    public static string GetSortPropertyNotSupportedMessage(PostSortProperty sortProperty)
    {
        const string Format = "PostSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostIncludeProperty> includeProperties)
    {
        const string Format = "PostIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
