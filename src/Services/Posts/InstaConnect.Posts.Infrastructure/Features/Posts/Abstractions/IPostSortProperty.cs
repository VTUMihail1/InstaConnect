using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostSortProperty
{
    public PostSortProperty SortProperty { get; }

    public Expression<Func<Post, object>> Property { get; }
}
