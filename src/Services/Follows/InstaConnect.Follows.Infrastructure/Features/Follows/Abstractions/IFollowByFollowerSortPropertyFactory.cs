using InstaConnect.Common.Models.Enums;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IFollowByFollowerSortPropertyFactory
{
    IFollowByFollowerSortProperty Create(FollowByFollowerSortProperty sortProperty);
}
