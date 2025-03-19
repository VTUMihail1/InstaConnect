using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public class PostTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);

    public static readonly string ValidAddTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    public static readonly string ValidUpdateTitle = GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);

    public static readonly string ValidAddContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
    public static readonly string ValidUpdateContent = GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);

    public static readonly DateTimeOffset ValidUpdateUpdatedAtUtc = GetMaxDate();

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;

    public static Post CreatePost(
        User user,
        ICollection<PostLike> postLikes,
        ICollection<PostComment> postComments)
    {
        var post = new Post(
            GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength),
            GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user,
            postLikes,
            postComments,
            GetMaxDate(),
            GetMaxDate());

        return post;
    }
}
