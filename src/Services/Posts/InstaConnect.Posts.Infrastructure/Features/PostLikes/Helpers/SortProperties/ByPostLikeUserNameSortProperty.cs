using System.Linq.Expressions;

using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostLikeUserNameSortProperty : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByUserName;

    public Expression<Func<PostLike, object>> Property => p => p.User!.Name;
}
