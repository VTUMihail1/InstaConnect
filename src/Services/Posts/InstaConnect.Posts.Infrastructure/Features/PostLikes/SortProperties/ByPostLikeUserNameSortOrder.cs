using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostLikeUserNameSortOrder : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByUserName;

    public string Property => PostLikeSortPropertyUtilities.ByUserName;
}
