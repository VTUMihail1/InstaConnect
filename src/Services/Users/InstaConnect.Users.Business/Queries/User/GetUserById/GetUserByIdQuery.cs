using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetUserById;

public class GetUserByIdQuery : IQuery<UserViewModel>
{
    public string Id { get; set; }
}
