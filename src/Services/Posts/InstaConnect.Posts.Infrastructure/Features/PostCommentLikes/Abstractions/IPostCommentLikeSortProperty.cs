using System.Linq.Expressions;

using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty { get; }

    public Expression<Func<PostCommentLike, object>> Property { get; }
}
