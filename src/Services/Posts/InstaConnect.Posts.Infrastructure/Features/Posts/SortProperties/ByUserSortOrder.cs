using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserSortOrder : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByUser;

    public string Property => PostSortPropertyUtilities.ByUser;
}
