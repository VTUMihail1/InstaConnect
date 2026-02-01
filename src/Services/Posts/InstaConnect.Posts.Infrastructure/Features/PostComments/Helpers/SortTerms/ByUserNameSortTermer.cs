using System.Linq.Expressions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortTerms;

internal class ByUserNameSortTermer : IPostCommentsSortTermer
{
    public PostCommentsSortTerm SortTerm => PostCommentsSortTerm.ByUserName;

    public Expression<Func<PostCommentResponse, object>> Term => p => p.User!.Name;
}
