using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Common.Features.Users.Utilities;
public class UserTestUtilities : SharedTestUtilities
{
    public static readonly string ValidCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
}
