using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Common.Features.Users.Utilities;
public class UserTestUtilities : SharedTestUtilities
{
    public static readonly string ValidCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
}
