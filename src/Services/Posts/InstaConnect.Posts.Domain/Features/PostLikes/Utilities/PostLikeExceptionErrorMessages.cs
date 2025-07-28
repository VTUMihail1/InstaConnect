using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

public static class PostLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string likeId)
    {
        const string Format = "PostLike(id: {0}, likeId: {1}) with that id does not exist";
        var result = Format.FormatInvariantCulture(id, likeId);

        return result;
    }

    public static string GetAlreadyExistsMessage(string id, string userId)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) already exists";
        var result = Format.FormatInvariantCulture(id, userId);

        return result;
    }

    public static string GetForbiddenMessage(string id, string likeId, string userId)
    {
        const string Format = "PostLike(id: {0}, likeId: {1}) is not owned by User(id: {2})";
        var result = Format.FormatInvariantCulture(id, likeId, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostLikeSortProperty sortProperty)
    {
        const string Format = "PostLikeSortProperty(type: {0}) is not supported";
        var result = Format.FormatInvariantCulture(sortProperty);

        return result;
    }
}
