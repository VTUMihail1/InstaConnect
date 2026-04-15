using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IRefreshTokenCommandRepository GetRefreshTokenCommandRepository()
        {
            return serviceProvider.GetRequiredService<IRefreshTokenCommandRepository>();
        }

        public IRefreshTokenIncludeBuilderFactory GetRefreshTokenIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IRefreshTokenIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IRefreshTokenCommandRepository GetRefreshTokenCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRefreshTokenCommandRepository();
        }

        public IRefreshTokenIncludeBuilderFactory GetRefreshTokenIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRefreshTokenIncludeBuilderFactory();
        }

        public async Task<RefreshToken?> GetRefreshTokenByIdAsync(
            RefreshTokenId id,
            CancellationToken cancellationToken)
        {
            var refreshTokenInclude = serviceScope.GetRefreshTokenIncludeBuilderFactory().Create().WithUser().Build();

            return await serviceScope.GetRefreshTokenCommandRepository().GetByIdAsync(id, refreshTokenInclude, cancellationToken);
        }

        public async Task AddRefreshTokenAsync(
            RefreshToken refreshToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetRefreshTokenCommandRepository().AddAsync(refreshToken, cancellationToken);
        }

        public async Task AddRefreshTokenRangeAsync(
            IEnumerable<RefreshToken> refreshTokens,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetRefreshTokenCommandRepository().AddRangeAsync(refreshTokens, cancellationToken);
        }

        public async Task UpdateRefreshTokenAsync(
            RefreshToken refreshToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetRefreshTokenCommandRepository().UpdateAsync(refreshToken, cancellationToken);
        }

        public async Task DeleteRefreshTokenAsync(
            RefreshToken refreshToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetRefreshTokenCommandRepository().DeleteAsync(refreshToken, cancellationToken);
        }
    }
}

