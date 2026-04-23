using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Utilities;

public static class FollowExceptionErrorMessages
{
    public static string GetNotFoundMessage(FollowId id)
    {
        const string Format = "Follow(followerId: {0}, followingId: {1}) with that id does not exist";

        return Format.FormatCurrentCulture(id.FollowerId.Id, id.FollowingId.Id);
    }

    public static string GetAlreadyExistsMessage(FollowId id)
    {
        const string Format = "Follow(followerId: {0}, followingId: {1}) already exists";

        return Format.FormatCurrentCulture(id.FollowerId.Id, id.FollowingId.Id);
    }

    public static string GetSortTermNotSupportedMessage(FollowsSortTerm sortTerm)
    {
        const string Format = "FollowsSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetSortTermNotSupportedMessage(FollowsForFollowingSortTerm sortTerm)
    {
        const string Format = "FollowsForFollowingSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<FollowsIncludeDescriptor> descriptors)
    {
        const string Format = "FollowIncludeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>());
    }
}
