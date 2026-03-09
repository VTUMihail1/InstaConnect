using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
    extension(IServiceScope serviceScope)
    {
        public IRefreshTokenCommandRepository GetRefreshTokenCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IRefreshTokenCommandRepository>();
        }

        public IRefreshTokenIncludeBuilderFactory GetRefreshTokenIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IRefreshTokenIncludeBuilderFactory>();
        }

        public async Task AddRefreshTokenAsync(
            RefreshToken refreshToken,
            CancellationToken cancellationToken)
        {
            var refreshTokenRepository = serviceScope.GetRefreshTokenCommandRepository();

            await refreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        }

        public async Task AddRefreshTokenRangeAsync(
            IEnumerable<RefreshToken> refreshTokens,
            CancellationToken cancellationToken)
        {
            var refreshTokenRepository = serviceScope.GetRefreshTokenCommandRepository();

            await refreshTokenRepository.AddRangeAsync(refreshTokens, cancellationToken);
        }

        public async Task ResetRefreshTokenDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IIdentityContext>();

            await context.RefreshTokens.ResetAsync(cancellationToken);
        }
    }
}
