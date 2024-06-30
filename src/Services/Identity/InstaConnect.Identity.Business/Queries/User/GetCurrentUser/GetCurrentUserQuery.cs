using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetCurrentUser;

public class GetCurrentUserQuery : IQuery<UserViewModel>, ICachable
{
    public string CurrentUserId { get; set; }

    public string Key { get; set; }

    public DateTimeOffset Expiration { get; set; }
}
