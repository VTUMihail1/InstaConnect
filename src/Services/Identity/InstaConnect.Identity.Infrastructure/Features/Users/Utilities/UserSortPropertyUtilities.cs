using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class UserSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(UserQueryEntity.CreatedAt);

    public const string ByFirstName = nameof(UserQueryEntity.FirstName);

    public const string ByLastName = nameof(UserQueryEntity.LastName);

    public const string ByName = nameof(UserQueryEntity.Name);
}
