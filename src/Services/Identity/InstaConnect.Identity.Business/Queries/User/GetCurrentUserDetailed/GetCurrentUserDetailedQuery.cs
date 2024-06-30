using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;

public class GetCurrentUserDetailedQuery : IQuery<UserDetailedViewModel>, ICachable
{
    public string CurrentUserId { get; set; }

    public string Key { get; set; }

    public DateTimeOffset Expiration { get; set; }
}
