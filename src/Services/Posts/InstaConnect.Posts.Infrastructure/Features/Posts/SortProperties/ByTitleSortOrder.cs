using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByTitleSortOrder : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByTitle;

    public string Property => PostSortPropertyUtilities.ByTitle;
}
