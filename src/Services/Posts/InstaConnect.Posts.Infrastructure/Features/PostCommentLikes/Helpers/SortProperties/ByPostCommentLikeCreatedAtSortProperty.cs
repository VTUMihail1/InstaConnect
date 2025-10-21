using System.Linq.Expressions;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class ByPostCommentLikeCreatedAtSortProperty : IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty => PostCommentLikeSortProperty.ByCreatedAt;

    public Expression<Func<PostCommentLike, object>> Property => p => p.CreatedAt;
}
