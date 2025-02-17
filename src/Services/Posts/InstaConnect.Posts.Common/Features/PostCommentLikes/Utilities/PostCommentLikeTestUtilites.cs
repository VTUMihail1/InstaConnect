namespace InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;

public class PostCommentLikeTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostCommentLikeConfigurations.IdMaxLength, PostCommentLikeConfigurations.IdMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
