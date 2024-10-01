using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;

public class PostCommentLikeTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidPostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
    public static readonly string InvalidPostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
    public static readonly string ValidPostCommentContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidCurrentUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidPostCommentLikePostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
    public static readonly string ValidPostCommentLikeCurrentUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidPostTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
    public static readonly string ValidPostContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
}
