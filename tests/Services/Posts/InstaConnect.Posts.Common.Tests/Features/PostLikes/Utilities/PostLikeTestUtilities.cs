using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

public class PostLikeTestUtilities : DataFaker
{
    public static readonly string InvalidId = GetAverageString(PostLikeConfigurations.IdMaxLength, PostLikeConfigurations.IdMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;

    public static PostLike CreatePostLike(User user, Post post)
    {
        var postLike = new PostLike(
            GetAverageString(PostLikeConfigurations.IdMaxLength, PostLikeConfigurations.IdMinLength),
            post,
            user,
            GetMaxDate(),
            GetMaxDate());

        return postLike;
    }
}
