using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Utilities;

public static class PostLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string userId)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) with that id does not exist";
        var result = Format.FormatCurrentCulture(id, userId);

        return result;
    }

    public static string GetAlreadyExistsMessage(string id, string userId)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) already exists";
        var result = Format.FormatCurrentCulture(id, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostLikeSortProperty sortProperty)
    {
        const string Format = "PostLikeSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostLikeIncludeProperty> includeProperties)
    {
        const string Format = "PostLikeIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
