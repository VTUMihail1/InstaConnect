using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public class PostTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);

    public static readonly string ValidAddTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    public static readonly string ValidUpdateTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);

    public static readonly string ValidAddContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
    public static readonly string ValidUpdateContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;

    public static Post CreatePost()
    {
        var post = new Post(
            GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength),
            GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            GetMaxDate(),
            GetMaxDate());

        return post;
    }
}
