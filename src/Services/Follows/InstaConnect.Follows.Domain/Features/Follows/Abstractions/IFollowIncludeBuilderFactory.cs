using InstaConnect.Follows.Domain.Features.Follows.Helpers;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowIncludeBuilderFactory
{
    FollowIncludeBuilder Create();
}