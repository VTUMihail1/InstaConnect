using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserLastNameSortOrder : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByLastName;

    public string Property => UserSortPropertyUtilities.ByLastName;
}
