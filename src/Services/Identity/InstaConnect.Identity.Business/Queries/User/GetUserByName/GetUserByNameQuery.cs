using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetUserByName;

public class GetUserByNameQuery : IQuery<UserViewModel>
{
    public string UserName { get; set; } = string.Empty;
}
