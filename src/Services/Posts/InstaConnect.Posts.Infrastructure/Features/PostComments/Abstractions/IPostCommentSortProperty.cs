using System.Linq.Expressions;

using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty { get; }

    public Expression<Func<PostComment, object>> Property { get; }
}
