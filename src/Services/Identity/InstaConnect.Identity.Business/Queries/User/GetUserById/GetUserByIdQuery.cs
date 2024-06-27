using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetUserById;

public class GetUserByIdQuery : IQuery<UserViewModel>
{
    public string Id { get; set; }
}
