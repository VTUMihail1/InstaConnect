using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTerms;

internal class ByCreatedAtSortTermer : IPostCommentsSortTermer
{
    public PostCommentsSortTerm SortTerm => PostCommentsSortTerm.ByCreatedAt;

    public Expression<Func<PostCommentResponse, object>> Term => p => p.CreatedAtUtc;
}
