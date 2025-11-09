using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortProperties;

public class ByPostCommentUserNameSortProperty : IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty => PostCommentSortProperty.ByUserName;

    public Expression<Func<PostComment, object>> Property => p => p.User!.Name;
}
