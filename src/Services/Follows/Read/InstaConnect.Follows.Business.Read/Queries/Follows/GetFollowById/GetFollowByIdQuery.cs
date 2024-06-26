using InstaConnect.Follows.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetFollowById;

public class GetFollowByIdQuery : IQuery<FollowViewModel>
{
    public string Id { get; set; }
}
