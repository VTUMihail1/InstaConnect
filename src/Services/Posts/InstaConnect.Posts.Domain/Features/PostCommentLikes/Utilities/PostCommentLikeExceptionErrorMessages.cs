using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(
        string id, 
        string commentId, 
        string commentLikeId)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, commentLikeId: {2}) with that id does not exist";
        var result = Format.FormatInvariantCulture(id, commentId, commentLikeId);

        return result;
    }

    public static string GetAlreadyExistsMessage(string id, string commentId, string userId)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) already exists";
        var result = Format.FormatInvariantCulture(id, commentId, userId);

        return result;
    }

    public static string GetForbiddenMessage(
        string id, 
        string commentId, 
        string commentLikeId,
        string userId)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, commentLikeId: {2}) is not owned by User(id: {1})";
        var result = Format.FormatInvariantCulture(id, commentId, commentLikeId, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostCommentLikeSortProperty sortProperty)
    {
        const string Format = "PostCommentLikeSortProperty(type: {0}) is not supported";
        var result = Format.FormatInvariantCulture(sortProperty);

        return result;
    }
}
