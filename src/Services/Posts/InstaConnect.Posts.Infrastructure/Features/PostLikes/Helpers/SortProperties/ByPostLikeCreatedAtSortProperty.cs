using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortProperties;
public class ByPostLikeCreatedAtSortProperty : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByCreatedAt;

    public Expression<Func<PostLike, object>> Property => p => p.CreatedAt;
}
