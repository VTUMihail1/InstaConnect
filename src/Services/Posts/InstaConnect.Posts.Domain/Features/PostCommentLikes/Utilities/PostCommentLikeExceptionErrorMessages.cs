using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostCommentLikeId id)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) with that id does not exist";
        var result = Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);

        return result;
    }

    public static string GetAlreadyExistsMessage(PostCommentLikeId id)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) already exists";
        var result = Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(PostCommentLikeSortProperty sortProperty)
    {
        const string Format = "PostCommentLikeSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostCommentLikeIncludeProperty> includeProperties)
    {
        const string Format = "PostCommentLikeIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());

        return result;
    }
}
