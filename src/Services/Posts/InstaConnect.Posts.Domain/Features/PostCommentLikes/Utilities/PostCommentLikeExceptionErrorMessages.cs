using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(
        string id, 
        string commentId, 
        string userId)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) with that id does not exist";
        var result = Format.FormatCurrentCulture(id, commentId, userId);

        return result;
    }

    public static string GetAlreadyExistsMessage(string id, string commentId, string userId)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) already exists";
        var result = Format.FormatCurrentCulture(id, commentId, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostCommentLikeSortProperty sortProperty)
    {
        const string Format = "PostCommentLikeSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }
}
