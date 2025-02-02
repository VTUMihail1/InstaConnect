using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Common.Features.Messages.Utilities;

public class MessageTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(MessageConfigurations.IdMaxLength, MessageConfigurations.IdMinLength);
    
    public static readonly string ValidContent = GetAverageString(MessageConfigurations.ContentMaxLength, MessageConfigurations.ContentMinLength);
    public static readonly string ValidAddContent = GetAverageString(MessageConfigurations.ContentMaxLength, MessageConfigurations.ContentMinLength);
    public static readonly string ValidUpdateContent = GetAverageString(MessageConfigurations.ContentMaxLength, MessageConfigurations.ContentMinLength);
    
    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
