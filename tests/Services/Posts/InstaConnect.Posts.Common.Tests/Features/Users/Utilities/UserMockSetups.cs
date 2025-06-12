using InstaConnect.Posts.Domain.Features.Users.Abstractions;

using NSubstitute;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
    public static void SetupGetByIdAsync(this IUserWriteRepository userWriteRepository, User user, CancellationToken cancellationToken)
    {
        userWriteRepository.GetByIdAsync(user.Id, cancellationToken).Returns(user);
    }
}
