using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IFollowByFollowingSortPropertyFactory
{
    IFollowByFollowingSortProperty Create(FollowByFollowingSortProperty sortProperty);
}
