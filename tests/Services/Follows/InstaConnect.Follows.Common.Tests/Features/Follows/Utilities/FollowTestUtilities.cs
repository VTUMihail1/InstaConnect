using InstaConnect.Follows.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Follows.Common.Tests.Features.Follows.Utilities;

public class FollowTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(FollowConfigurations.IdMaxLength, FollowConfigurations.IdMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;

    public static Follow CreateFollow(User follower, User following)
    {
        var follow = new Follow(
            GetAverageString(FollowConfigurations.IdMaxLength, FollowConfigurations.IdMinLength),
            follower,
            following,
            GetMaxDate(),
            GetMaxDate());

        return follow;
    }
}
