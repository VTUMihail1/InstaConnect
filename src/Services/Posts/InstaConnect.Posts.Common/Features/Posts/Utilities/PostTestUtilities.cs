﻿using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Common.Features.Posts.Utilities;

public class PostTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(PostBusinessConfigurations.ID_MAX_LENGTH, PostBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(PostBusinessConfigurations.ID_MAX_LENGTH, PostBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
    public static readonly string ValidContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string InvalidUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserFirstName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserLastName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserEmail = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUserProfileImage = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidCurrentUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidPostCurrentUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
    public static readonly string ValidAddUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    public static readonly string ValidAddTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
    public static readonly string ValidUpdateTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
    public static readonly string ValidAddContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
    public static readonly string ValidUpdateContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
