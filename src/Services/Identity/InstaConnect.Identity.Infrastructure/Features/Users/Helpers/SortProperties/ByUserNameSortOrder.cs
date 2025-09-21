using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserNameSortOrder : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByName;

    public string Property => UserSortPropertyUtilities.ByName;
}
