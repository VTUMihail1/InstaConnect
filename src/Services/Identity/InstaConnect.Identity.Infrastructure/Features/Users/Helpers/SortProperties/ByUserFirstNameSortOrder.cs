using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserFirstNameSortOrder : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByFirstName;

    public string Property => UserSortPropertyUtilities.ByFirstName;
}
