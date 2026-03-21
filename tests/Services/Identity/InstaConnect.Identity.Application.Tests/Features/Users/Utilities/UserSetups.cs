using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<User?> GetUserByIdAsync(
        UserIdCommandResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetUserByIdAsync(
                new UserId(id.Id),
                cancellationToken);
        }
    }
}
