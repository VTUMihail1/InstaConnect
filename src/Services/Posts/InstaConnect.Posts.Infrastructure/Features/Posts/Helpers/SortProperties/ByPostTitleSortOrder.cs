using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostTitleSortOrder : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByTitle;

    public string Property => PostSortPropertyUtilities.ByTitle;
}
