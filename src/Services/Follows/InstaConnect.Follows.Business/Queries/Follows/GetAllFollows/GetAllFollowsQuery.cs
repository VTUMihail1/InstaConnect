using InstaConnect.Follows.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;

public class GetAllFollowsQuery : CollectionModel, IQuery<ICollection<FollowViewModel>>
{
}
