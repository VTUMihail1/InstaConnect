using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortProperties;
public class ByPostCreatedAtSortProperty : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByCreatedAt;

    public Expression<Func<Post, object>> Property => p => p.CreatedAt;
}
