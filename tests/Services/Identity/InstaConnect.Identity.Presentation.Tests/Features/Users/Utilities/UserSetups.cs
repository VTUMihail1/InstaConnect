using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<User?> GetUserByIdAsync(
        UserIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetUserByIdAsync(
                new UserId(id.Id),
                cancellationToken);
        }
    }
}
