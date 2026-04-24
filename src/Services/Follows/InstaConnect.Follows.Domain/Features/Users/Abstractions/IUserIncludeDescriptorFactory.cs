using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollowFollowers();

    FollowsIncludeDescriptor CreateFollowFollowings();
}
