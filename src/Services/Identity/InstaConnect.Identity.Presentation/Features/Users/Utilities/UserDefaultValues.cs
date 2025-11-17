using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.Users.Utilities;

public static class UserDefaultValues
{
    public const string FirstName = "";

    public const string LastName = "";

    public const string Name = "";

    public const UserSortProperty SortProperty = UserSortProperty.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
