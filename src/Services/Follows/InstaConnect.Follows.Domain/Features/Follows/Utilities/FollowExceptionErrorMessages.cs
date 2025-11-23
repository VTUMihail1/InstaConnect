using InstaConnect.Common.Domain.Extensions;

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

    public static string GetByFollowerSortPropertyNotSupportedMessage(FollowByFollowerSortProperty sortProperty)
    {
        const string Format = "FollowByFollowerSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetByFollowingSortPropertyNotSupportedMessage(FollowByFollowingSortProperty sortProperty)
    {
        const string Format = "FollowByFollowingSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<FollowIncludeProperty> includeProperties)
    {
        const string Format = "FollowIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
