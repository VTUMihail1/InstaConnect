using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<Follow?> GetFollowByIdAsync(
        FollowIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetFollowByIdAsync(
                new FollowId(
                               new(id.FollowerId),
                               new(id.FollowingId)),
                cancellationToken);
        }
    }
}
