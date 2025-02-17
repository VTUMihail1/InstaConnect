namespace InstaConnect.Posts.Common.Features.PostComments.Utilities;

public class PostCommentTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostCommentConfigurations.IdMaxLength, PostCommentConfigurations.IdMinLength);

    public static readonly string ValidAddContent = GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength);
    public static readonly string ValidUpdateContent = GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
