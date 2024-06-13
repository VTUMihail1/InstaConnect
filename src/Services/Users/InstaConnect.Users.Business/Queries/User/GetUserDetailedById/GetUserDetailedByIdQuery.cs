using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetUserDetailed;

public class GetUserDetailedByIdQuery : IQuery<UserDetailedViewDTO>
{
    public string Id { get; set; }
}
