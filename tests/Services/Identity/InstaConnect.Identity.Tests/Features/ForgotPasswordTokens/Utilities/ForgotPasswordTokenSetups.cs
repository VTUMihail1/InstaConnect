using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
        {
            return serviceProvider.GetRequiredService<IForgotPasswordTokenCommandRepository>();
        }

        public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IForgotPasswordTokenIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
        {
            return serviceScope.ServiceProvider.GetForgotPasswordTokenCommandRepository();
        }

        public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetForgotPasswordTokenIncludeBuilderFactory();
        }

        public async Task<ForgotPasswordToken?> GetForgotPasswordTokenByIdAsync(
            ForgotPasswordTokenId id,
            CancellationToken cancellationToken)
        {
            return await serviceScope.GetForgotPasswordTokenCommandRepository().GetByIdAsync(id, cancellationToken);
        }

        public async Task AddForgotPasswordTokenAsync(
            ForgotPasswordToken forgotPasswordToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetForgotPasswordTokenCommandRepository().AddAsync(forgotPasswordToken, cancellationToken);
        }

        public async Task AddForgotPasswordTokenRangeAsync(
            IEnumerable<ForgotPasswordToken> forgotPasswordTokens,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetForgotPasswordTokenCommandRepository().AddRangeAsync(forgotPasswordTokens, cancellationToken);
        }

        public async Task DeleteForgotPasswordTokenAsync(
            ForgotPasswordToken forgotPasswordToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetForgotPasswordTokenCommandRepository().DeleteAsync(forgotPasswordToken, cancellationToken);
        }
    }
}
