using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
    extension(IServiceScope serviceScope)
    {
        public IUserClaimCommandRepository GetUserClaimCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IUserClaimCommandRepository>();
        }

        public IUserClaimIncludeBuilderFactory GetUserClaimIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IUserClaimIncludeBuilderFactory>();
        }

        public async Task AddUserClaimAsync(
            UserClaim userClaim,
            CancellationToken cancellationToken)
        {
            var userClaimRepository = serviceScope.GetUserClaimCommandRepository();

            await userClaimRepository.AddAsync(userClaim, cancellationToken);
        }

        public async Task AddUserClaimRangeAsync(
            IEnumerable<UserClaim> userClaims,
            CancellationToken cancellationToken)
        {
            var userClaimRepository = serviceScope.GetUserClaimCommandRepository();

            await userClaimRepository.AddRangeAsync(userClaims, cancellationToken);
        }

        public async Task ResetUserClaimDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IIdentityContext>();

            await context.UserClaims.ResetAsync(cancellationToken);
        }
    }
}
