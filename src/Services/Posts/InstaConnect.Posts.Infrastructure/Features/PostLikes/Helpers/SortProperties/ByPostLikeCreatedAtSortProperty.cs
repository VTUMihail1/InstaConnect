using System.Linq.Expressions;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class ByPostLikeCreatedAtSortProperty : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByCreatedAt;

    public Expression<Func<PostLike, object>> Property => p => p.CreatedAt;
}
