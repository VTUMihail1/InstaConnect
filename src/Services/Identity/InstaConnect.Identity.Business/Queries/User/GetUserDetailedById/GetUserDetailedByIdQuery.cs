using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;

public class GetUserDetailedByIdQuery : IQuery<UserDetailedViewModel>
{
    public string Id { get; set; } = string.Empty;
}
