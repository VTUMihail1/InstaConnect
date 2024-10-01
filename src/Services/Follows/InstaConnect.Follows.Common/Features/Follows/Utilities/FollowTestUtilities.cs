using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Common.Features.Follows.Utilities;

public class FollowTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(FollowBusinessConfigurations.ID_MAX_LENGTH, FollowBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(FollowBusinessConfigurations.ID_MAX_LENGTH, FollowBusinessConfigurations.ID_MIN_LENGTH);

    public static readonly string ValidCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidFollowingId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);

    public static readonly string ValidUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);

    public static readonly string ValidFollowFollowingId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
    public static readonly string ValidFollowCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

    public static readonly string ValidAddUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
