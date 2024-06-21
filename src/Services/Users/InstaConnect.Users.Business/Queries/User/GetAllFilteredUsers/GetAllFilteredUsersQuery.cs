using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;

public class GetAllFilteredUsersQuery : CollectionModel, IQuery<ICollection<UserViewModel>>
{
    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
