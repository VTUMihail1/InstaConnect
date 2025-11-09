using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty { get; }

    public Expression<Func<PostComment, object>> Property { get; }
}
