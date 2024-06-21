using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetAllUsers;

public class GetAllUsersQuery : CollectionModel, IQuery<ICollection<UserViewModel>>
{
}
