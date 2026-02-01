using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortTerms;

internal class ByCreatedAtSortTermer : IPostCommentLikesSortTermer
{
    public PostCommentLikesSortTerm SortTerm => PostCommentLikesSortTerm.ByCreatedAt;

    public Expression<Func<PostCommentLikeResponse, object>> Term => p => p.CreatedAtUtc;
}
