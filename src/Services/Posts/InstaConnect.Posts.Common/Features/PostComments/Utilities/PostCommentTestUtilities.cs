using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Common.Features.PostComments.Utilities;

public class PostCommentTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(PostCommentBusinessConfigurations.ID_MAX_LENGTH, PostCommentBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(PostCommentBusinessConfigurations.ID_MAX_LENGTH, PostCommentBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
    public static readonly string InvalidPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
    public static readonly string ValidPostTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
    public static readonly string ValidPostContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string ValidContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidCurrentUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidPostCommentPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
    public static readonly string ValidPostCommentCurrentUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidAddContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string ValidUpdateContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
