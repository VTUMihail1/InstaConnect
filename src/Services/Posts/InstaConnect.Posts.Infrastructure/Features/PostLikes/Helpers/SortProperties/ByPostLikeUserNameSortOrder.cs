using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortProperties;

public class ByPostLikeUserNameSortOrder : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByUserName;

    public string Property => PostLikeSortPropertyUtilities.ByUserName;
}
