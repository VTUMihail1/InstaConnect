using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.User.GetUserById
{
    public class GetUserByIdQuery : IQuery<UserViewDTO>
    {
        public string Id { get; set; }
    }
}
