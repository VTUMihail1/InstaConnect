using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;

public class PostCommentLikeTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostCommentLikeConfigurations.IdMaxLength, PostCommentLikeConfigurations.IdMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;

    public static PostCommentLike CreatePostCommentLike()
    {
        var postCommentLike = new PostCommentLike(
            GetAverageString(PostCommentLikeConfigurations.IdMaxLength, PostCommentLikeConfigurations.IdMinLength),
            GetAverageString(PostCommentConfigurations.IdMaxLength, PostCommentConfigurations.IdMinLength),
            GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            GetMaxDate(),
            GetMaxDate());

        return postCommentLike;
    }
}
