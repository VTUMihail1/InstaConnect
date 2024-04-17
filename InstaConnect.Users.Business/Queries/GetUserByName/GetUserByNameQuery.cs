using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.GetUserByName
{
    public class GetUserByNameQuery : IQuery<UserViewDTO>
    {
        public string UserName { get; set; }
    }
}
