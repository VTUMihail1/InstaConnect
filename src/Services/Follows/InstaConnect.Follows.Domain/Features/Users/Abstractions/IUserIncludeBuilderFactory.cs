using InstaConnect.Follows.Domain.Features.Users.Helpers;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IUserIncludeBuilderFactory
{
    UserIncludeBuilder Create();
}
