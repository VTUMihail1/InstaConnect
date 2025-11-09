using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortProperties;

public class ByPostTitleSortProperty : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByTitle;

    public Expression<Func<Post, object>> Property => p => p.Title;
}
