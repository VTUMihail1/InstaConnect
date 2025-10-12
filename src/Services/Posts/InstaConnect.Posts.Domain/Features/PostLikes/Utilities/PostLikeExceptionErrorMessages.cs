using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

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
}
