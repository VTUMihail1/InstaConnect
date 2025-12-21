using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortProperties;

public class ByPostCommentLikeUserNameSortProperty : IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty => PostCommentLikeSortProperty.ByUserName;

    public Expression<Func<PostCommentLike, object>> Property => p => p.User!.Name.Value;
}
