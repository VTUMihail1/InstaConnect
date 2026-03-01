using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Utilities;

public static class PostExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostId id)
    {
        const string Format = "Post(id: {0}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetForbiddenMessage(PostId id, UserId userId)
    {
        const string Format = "Post(id: {0}) is not owned by User(id: {1})";

        return Format.FormatCurrentCulture(id.Id, userId.Id);
    }

    public static string GetSortTermNotSupportedMessage(PostsSortTerm sortTerm)
    {
        const string Format = "PostsSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetSortTermNotSupportedMessage(PostsForUserSortTerm sortTerm)
    {
        const string Format = "PostsForUserSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetInclideDescriptorsNotSupportedMessage(ICollection<PostsIncludeDescriptor> descriptors)
    {
        const string Format = "PostIncludeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>());
    }
}
