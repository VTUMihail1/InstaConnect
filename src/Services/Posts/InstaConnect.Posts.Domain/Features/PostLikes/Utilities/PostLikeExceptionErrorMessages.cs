using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

public static class PostLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string postId)
    {
        const string Format = "PostLike(id: {0}, postId: {1}) with that id does not exist";
        var result = Format.FormatInvariantCulture(id, postId);

        return result;
    }

    public static string GetForbiddenMessage(string id, string postId, string userId)
    {
        const string Format = "PostLike(id: {0}, postId: {1}) is not owned by User(id: {1})";
        var result = Format.FormatInvariantCulture(id, postId, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostLikeSortProperty sortProperty)
    {
        const string Format = "PostLikeSortProperty(type: {0}) is not supported";
        var result = Format.FormatInvariantCulture(sortProperty);

        return result;
    }
}
