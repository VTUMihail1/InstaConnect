using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTerms;

internal class ByUserNameSortTermer : IPostCommentLikesSortTermer
{
    public PostCommentLikesSortTerm SortTerm => PostCommentLikesSortTerm.ByUserName;

    public Expression<Func<PostCommentLikeResponse, object>> Term => p => p.User!.Name.Value;
}
