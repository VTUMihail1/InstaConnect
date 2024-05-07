using InstaConnect.Follows.Business.Models;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Follows.Business.Queries.Follows.GetFollowById;

public class GetFollowByIdQuery : IQuery<FollowViewDTO>
{
    public string Id { get; set; }
}
