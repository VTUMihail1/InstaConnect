using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
internal interface IFollowCollectionFactory
{
    FollowCollection Create(
        ICollection<Follow> follows,
        int totalCount,
        FollowPaginationQuery pagination);
}
