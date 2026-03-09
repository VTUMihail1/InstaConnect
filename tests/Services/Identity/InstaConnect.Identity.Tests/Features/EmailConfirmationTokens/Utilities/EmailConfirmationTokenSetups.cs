using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenSetups
{
    extension(IServiceScope serviceScope)
    {
        public IEmailConfirmationTokenCommandRepository GetEmailConfirmationTokenCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IEmailConfirmationTokenCommandRepository>();
        }

        public IEmailConfirmationTokenIncludeBuilderFactory GetEmailConfirmationTokenIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IEmailConfirmationTokenIncludeBuilderFactory>();
        }

        public async Task AddEmailConfirmationTokenAsync(
            EmailConfirmationToken emailConfirmationToken,
            CancellationToken cancellationToken)
        {
            var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

            await emailConfirmationTokenRepository.AddAsync(emailConfirmationToken, cancellationToken);
        }

        public async Task AddEmailConfirmationTokenRangeAsync(
            IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
            CancellationToken cancellationToken)
        {
            var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

            await emailConfirmationTokenRepository.AddRangeAsync(emailConfirmationTokens, cancellationToken);
        }

        public async Task ResetEmailConfirmationTokenDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IIdentityContext>();

            await context.EmailConfirmationTokens.ResetAsync(cancellationToken);
        }
    }
}
