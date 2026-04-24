using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostCommentLikeId id)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) with that id does not exist";

        return Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);
    }

    public static string GetAlreadyExistsMessage(PostCommentLikeId id)
    {
        const string Format = "PostCommentLike(id: {0}, commentId: {1}, userId: {2}) already exists";

        return Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);
    }

    public static string GetSortTermNotSupportedMessage(PostCommentLikesSortTerm sortTerm)
    {
        const string Format = "PostCommentLikesSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetSortTermNotSupportedMessage(PostCommentLikesForUserSortTerm sortTerm)
    {
        const string Format = "PostCommentLikesForUserSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<PostsIncludeDescriptor> descriptors)
    {
        const string Format = "PostCommentLikeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>());
    }
}
