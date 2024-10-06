using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Common.Features.Messages.Utilities;

public class MessageTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(MessageBusinessConfigurations.ID_MAX_LENGTH, MessageBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(MessageBusinessConfigurations.ID_MAX_LENGTH, MessageBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string ValidReceiverId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidMessageReceiverId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
    public static readonly string ValidMessageCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidAddContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string ValidUpdateContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
