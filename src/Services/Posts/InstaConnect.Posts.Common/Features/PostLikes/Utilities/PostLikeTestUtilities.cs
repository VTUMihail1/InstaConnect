using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Common.Features.PostLikes.Utilities;

public class PostLikeTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(PostLikeBusinessConfigurations.ID_MAX_LENGTH, PostLikeBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(PostLikeBusinessConfigurations.ID_MAX_LENGTH, PostLikeBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidPostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
    public static readonly string InvalidPostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
    public static readonly string ValidPostTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    public static readonly string ValidPostContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
    public static readonly string InvalidUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidCurrentUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidPostLikePostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
    public static readonly string ValidPostLikeCurrentUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
