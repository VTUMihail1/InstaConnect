using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;

public class GetAllFilteredUsersQuery : CollectionModel, IQuery<ICollection<UserViewModel>>
{
    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
