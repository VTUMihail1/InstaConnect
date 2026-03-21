using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IEmailConfirmationTokenCommandRepository GetEmailConfirmationTokenCommandRepository()
        {
            return serviceProvider.GetRequiredService<IEmailConfirmationTokenCommandRepository>();
        }

        public IEmailConfirmationTokenIncludeBuilderFactory GetEmailConfirmationTokenIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IEmailConfirmationTokenIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IEmailConfirmationTokenCommandRepository GetEmailConfirmationTokenCommandRepository()
        {
            return serviceScope.ServiceProvider.GetEmailConfirmationTokenCommandRepository();
        }

        public IEmailConfirmationTokenIncludeBuilderFactory GetEmailConfirmationTokenIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetEmailConfirmationTokenIncludeBuilderFactory();
        }

        public async Task<EmailConfirmationToken?> GetEmailConfirmationTokenByIdAsync(
            EmailConfirmationTokenId id,
            CancellationToken cancellationToken)
        {
            return await serviceScope.GetEmailConfirmationTokenCommandRepository().GetByIdAsync(id, cancellationToken);
        }

        public async Task AddEmailConfirmationTokenAsync(
            EmailConfirmationToken emailConfirmationToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetEmailConfirmationTokenCommandRepository().AddAsync(emailConfirmationToken, cancellationToken);
        }

        public async Task AddEmailConfirmationTokenRangeAsync(
            IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetEmailConfirmationTokenCommandRepository().AddRangeAsync(emailConfirmationTokens, cancellationToken);
        }

        public async Task DeleteEmailConfirmationTokenAsync(
            EmailConfirmationToken emailConfirmationToken,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetEmailConfirmationTokenCommandRepository().DeleteAsync(emailConfirmationToken, cancellationToken);
        }
    }
}
