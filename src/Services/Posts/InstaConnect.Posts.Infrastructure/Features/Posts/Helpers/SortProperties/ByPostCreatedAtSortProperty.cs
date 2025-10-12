using System.Linq.Expressions;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class ByPostCreatedAtSortProperty : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByCreatedAt;

    public Expression<Func<Post, object>> Property => p => p.CreatedAt;
}
