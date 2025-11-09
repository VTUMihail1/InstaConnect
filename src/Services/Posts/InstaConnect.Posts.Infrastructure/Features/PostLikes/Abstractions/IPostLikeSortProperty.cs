using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty { get; }

    public Expression<Func<PostLike, object>> Property { get; }
}
