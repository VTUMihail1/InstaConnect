using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserSetups
{
    public static async Task<User?> GetUserByIdAsync(
        this IServiceScope serviceScope,
        UserIdCommandResponse id,
        CancellationToken cancellationToken)
    {
        return await serviceScope.GetUserByIdAsync(
            new UserId(id.Id),
            cancellationToken);
    }
}
