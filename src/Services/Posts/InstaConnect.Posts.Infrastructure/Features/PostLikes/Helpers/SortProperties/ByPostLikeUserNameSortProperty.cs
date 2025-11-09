using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortProperties;

public class ByPostLikeUserNameSortProperty : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByUserName;

    public Expression<Func<PostLike, object>> Property => p => p.User!.Name;
}
