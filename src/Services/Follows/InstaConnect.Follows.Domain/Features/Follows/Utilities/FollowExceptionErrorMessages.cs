using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Common.Features.Follows.Utilities;

public static class FollowExceptionErrorMessages
{
    public static string GetNotFoundMessage(string followerId, string followingId)
    {
        const string Format = "Follow(followerId: {0}, followingId: {1}) with that id does not exist";
        var result = Format.FormatInvariantCulture(followerId, followingId);

        return result;
    }

    public static string GetAlreadyExistsMessage(string followerId, string followingId)
    {
        const string Format = "Follow(followerId: {0}, followingId: {1}) already exists";
        var result = Format.FormatInvariantCulture(followerId, followingId);

        return result;
    }

    public static string GetByFollowerSortPropertyNotSupportedMessage(FollowByFollowerSortProperty sortProperty)
    {
        const string Format = "FollowByFollowerSortProperty(type: {0}) is not supported";
        var result = Format.FormatInvariantCulture(sortProperty);

        return result;
    }

    public static string GetByFollowingSortPropertyNotSupportedMessage(FollowByFollowingSortProperty sortProperty)
    {
        const string Format = "FollowByFollowingSortProperty(type: {0}) is not supported";
        var result = Format.FormatInvariantCulture(sortProperty);

        return result;
    }
}
