using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Utilities;

public static class PostCommentExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostCommentId id)
    {
        const string Format = "PostComment(id: {0}, commentId: {1}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id.Id, id.CommentId);
    }

    public static string GetForbiddenMessage(PostCommentId id, UserId userId)
    {
        const string Format = "PostComment(id: {0}, commentId: {1}) is not owned by User(id: {2})";

        return Format.FormatCurrentCulture(id.Id.Id, id.CommentId, userId.Id);
    }

    public static string GetSortPropertyNotSupportedMessage(PostCommentSortProperty sortProperty)
    {
        const string Format = "PostCommentSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostCommentIncludeProperty> includeProperties)
    {
        const string Format = "PostCommentIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
