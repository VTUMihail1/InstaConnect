using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Utilities;

public static class PostCommentExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string commentId)
    {
        const string Format = "PostComment(id: {0}, commentId: {1}) with that id does not exist";
        var result = Format.FormatCurrentCulture(id);

        return result;
    }

    public static string GetForbiddenMessage(string id, string commentId, string userId)
    {
        const string Format = "PostComment(id: {0}, commentId: {1}) is not owned by User(id: {2})";
        var result = Format.FormatCurrentCulture(id, userId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostCommentSortProperty sortProperty)
    {
        const string Format = "PostCommentSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostCommentIncludeProperty> includeProperties)
    {
        const string Format = "PostCommentIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
