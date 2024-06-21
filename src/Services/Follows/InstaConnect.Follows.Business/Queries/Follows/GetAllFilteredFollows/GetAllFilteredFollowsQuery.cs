using InstaConnect.Follows.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFilteredFollows;

public class GetAllFilteredFollowsQuery : CollectionModel, IQuery<ICollection<FollowViewModel>>
{
    public string FollowerId { get; set; }

    public string FollowerName { get; set; }

    public string FollowingId { get; set; }

    public string FollowingName { get; set; }
}
