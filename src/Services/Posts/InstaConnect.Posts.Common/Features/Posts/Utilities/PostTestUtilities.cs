namespace InstaConnect.Posts.Common.Features.Posts.Utilities;

public class PostTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);

    public static readonly string ValidAddTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    public static readonly string ValidUpdateTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);

    public static readonly string ValidAddContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
    public static readonly string ValidUpdateContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
