using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

public class PostLikeTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostLikeConfigurations.IdMaxLength, PostLikeConfigurations.IdMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
