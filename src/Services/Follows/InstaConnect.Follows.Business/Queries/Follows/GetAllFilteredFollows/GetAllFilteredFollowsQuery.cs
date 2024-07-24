using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;

public class GetAllFilteredFollowsQuery : CollectionModel, IQuery<ICollection<FollowQueryViewModel>>
{
    public string FollowerId { get; set; } = string.Empty;

    public string FollowerName { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;

    public string FollowingName { get; set; } = string.Empty;
}
