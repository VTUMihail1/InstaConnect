using InstaConnect.Follows.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFollows;

public class GetAllFollowsQuery : CollectionModel, IQuery<ICollection<FollowViewModel>>
{
}
