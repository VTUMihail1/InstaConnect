using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Queries.GetPersonalUserById
{
    public class GetDetailedUserByIdQuery : IQuery<UserDetailedViewDTO>
    {
        public string Id { get; set; }
    }
}
