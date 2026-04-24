using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public static class FollowsSetups
{

    extension(IServiceProvider serviceProvider)
    {
        public IFollowsContext GetFollowsContext()
        {
            return serviceProvider.GetRequiredService<IFollowsContext>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IFollowsContext GetFollowsContext()
        {
            return serviceScope.ServiceProvider.GetFollowsContext();
        }

        public async Task ResetFollowsDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.GetFollowsContext();

            await context.Follows.ResetAsync(cancellationToken);
            await context.Users.ResetAsync(cancellationToken);
        }
    }
}
