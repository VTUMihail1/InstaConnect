using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortProperties;
public class ByPostCommentCreatedAtSortProperty : IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty => PostCommentSortProperty.ByCreatedAt;

    public Expression<Func<PostComment, object>> Property => p => p.CreatedAtUtc;
}
