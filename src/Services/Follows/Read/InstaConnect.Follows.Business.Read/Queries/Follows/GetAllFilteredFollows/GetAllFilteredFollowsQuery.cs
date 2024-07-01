using InstaConnect.Follows.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;

public class GetAllFilteredFollowsQuery : CollectionModel, IQuery<ICollection<FollowViewModel>>
{
    public string FollowerId { get; set; } = string.Empty;

    public string FollowerName { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;

    public string FollowingName { get; set; } = string.Empty;
}
