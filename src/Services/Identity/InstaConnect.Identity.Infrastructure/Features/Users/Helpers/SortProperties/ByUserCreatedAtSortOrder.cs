using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class ByUserCreatedAtSortOrder : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByCreatedAt;

    public string Property => UserSortPropertyUtilities.ByCreatedAt;
}
