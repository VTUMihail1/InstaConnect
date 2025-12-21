using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.SortProperties;

public class ByPostUserNameSortProperty : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByUserName;

    public Expression<Func<Post, object>> Property => p => p.User!.Name.Value;
}
