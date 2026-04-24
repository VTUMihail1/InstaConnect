using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Utilities;

public static class PostLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostLikeId id)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id);
    }

    public static string GetAlreadyExistsMessage(PostLikeId id)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) already exists";

        return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id);
    }

    public static string GetSortTermNotSupportedMessage(PostLikesSortTerm sortTerm)
    {
        const string Format = "PostLikesSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetSortTermNotSupportedMessage(PostLikesForUserSortTerm sortTerm)
    {
        const string Format = "PostLikesForUserSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<PostsIncludeDescriptor> descriptors)
    {
        const string Format = "PostLikeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>());
    }
}
