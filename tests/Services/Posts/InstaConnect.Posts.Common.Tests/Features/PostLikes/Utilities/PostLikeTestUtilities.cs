using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

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

    public static PostLike CreatePostLike()
    {
        var postLike = new PostLike(
            GetAverageString(PostLikeConfigurations.IdMaxLength, PostLikeConfigurations.IdMinLength),
            GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength),
            GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            GetMaxDate(),
            GetMaxDate());

        return postLike;
    }
}
