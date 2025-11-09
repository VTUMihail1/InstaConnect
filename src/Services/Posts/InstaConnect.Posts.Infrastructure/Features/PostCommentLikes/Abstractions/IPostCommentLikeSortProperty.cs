using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty { get; }

    public Expression<Func<PostCommentLike, object>> Property { get; }
}
