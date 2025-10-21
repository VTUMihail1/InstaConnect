using System.Linq.Expressions;

using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostCommentLikeUserNameSortProperty : IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty => PostCommentLikeSortProperty.ByUserName;

    public Expression<Func<PostCommentLike, object>> Property => p => p.User!.Name;
}
