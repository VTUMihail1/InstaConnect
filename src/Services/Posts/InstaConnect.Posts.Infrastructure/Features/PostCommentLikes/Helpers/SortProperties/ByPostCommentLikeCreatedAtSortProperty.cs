using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortProperties;
public class ByPostCommentLikeCreatedAtSortProperty : IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty => PostCommentLikeSortProperty.ByCreatedAt;

    public Expression<Func<PostCommentLike, object>> Property => p => p.CreatedAt;
}
