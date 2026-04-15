using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Posts.Domain.Models.Requests;

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

    public static string GetSortTermNotSupportedMessage(PostCommentsSortTerm sortTerm)
    {
        const string Format = "PostCommentsSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetSortTermNotSupportedMessage(PostCommentsForUserSortTerm sortTerm)
    {
        const string Format = "PostCommentsForUserSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetIncludePropertyNotSupportedMessage(ICollection<PostsIncludeDescriptor> descriptors)
    {
        const string Format = "PostCommentIncludeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>());
    }
}
