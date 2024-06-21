using InstaConnect.Follows.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Queries.Follows.GetFollowById;

public class GetFollowByIdQuery : IQuery<FollowViewModel>
{
    public string Id { get; set; }
}
