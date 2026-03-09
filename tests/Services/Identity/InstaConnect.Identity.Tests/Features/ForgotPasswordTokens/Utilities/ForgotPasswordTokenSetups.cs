using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
    extension(IServiceScope serviceScope)
    {
        public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IForgotPasswordTokenCommandRepository>();
        }

        public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IForgotPasswordTokenIncludeBuilderFactory>();
        }

        public async Task AddForgotPasswordTokenAsync(
            ForgotPasswordToken forgotPasswordToken,
            CancellationToken cancellationToken)
        {
            var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

            await forgotPasswordTokenRepository.AddAsync(forgotPasswordToken, cancellationToken);
        }

        public async Task AddForgotPasswordTokenRangeAsync(
            IEnumerable<ForgotPasswordToken> forgotPasswordTokens,
            CancellationToken cancellationToken)
        {
            var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

            await forgotPasswordTokenRepository.AddRangeAsync(forgotPasswordTokens, cancellationToken);
        }

        public async Task ResetForgotPasswordTokenDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IIdentityContext>();

            await context.ForgotPasswordTokens.ResetAsync(cancellationToken);
        }
    }
}
