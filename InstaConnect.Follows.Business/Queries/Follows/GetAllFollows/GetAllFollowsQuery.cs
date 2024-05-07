using InstaConnect.Follows.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;

public class GetAllFollowsQuery : CollectionDTO, IQuery<ICollection<FollowViewDTO>>
{
}
