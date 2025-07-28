using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserNameSortOrder : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByUserName;

    public string Property => PostSortPropertyUtilities.ByUserName;
}
