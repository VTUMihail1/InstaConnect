using InstaConnect.Follows.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;

public class GetAllFollowsQuery : CollectionDTO, IQuery<ICollection<FollowViewDTO>>
{
}
