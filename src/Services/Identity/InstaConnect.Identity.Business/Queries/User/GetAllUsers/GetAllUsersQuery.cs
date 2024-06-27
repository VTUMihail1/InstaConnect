using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Identity.Business.Queries.User.GetAllUsers;

public class GetAllUsersQuery : CollectionModel, IQuery<ICollection<UserViewModel>>
{
}
