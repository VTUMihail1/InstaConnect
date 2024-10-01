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
}
