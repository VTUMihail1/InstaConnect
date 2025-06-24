using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class ByCreatedAtSortOrder : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByCreatedAt;

    public string Property => PostSortPropertyUtilities.ByCreatedAt;
}
