using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Common.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public static class IdentitySetups
{

    extension(IServiceProvider serviceProvider)
    {
        public IPasswordHasher GetPasswordHasher()
        {
            return serviceProvider.GetRequiredService<IPasswordHasher>();
        }

        public IAccessTokenGenerator GetAccessTokenGenerator()
        {
            return serviceProvider.GetRequiredService<IAccessTokenGenerator>();
        }

        public IIdentityContext GetIdentityContext()
        {
            return serviceProvider.GetRequiredService<IIdentityContext>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IPasswordHasher GetPasswordHasher()
        {
            return serviceScope.ServiceProvider.GetPasswordHasher();
        }
        public IAccessTokenGenerator GetAccessTokenGenerator()
        {
            return serviceScope.ServiceProvider.GetAccessTokenGenerator();
        }

        public IIdentityContext GetIdentityContext()
        {
            return serviceScope.ServiceProvider.GetIdentityContext();
        }

        public async Task ResetIdentityDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.GetIdentityContext();

            await context.EmailConfirmationTokens.ResetAsync(cancellationToken);
            await context.ForgotPasswordTokens.ResetAsync(cancellationToken);
            await context.RefreshTokens.ResetAsync(cancellationToken);
            await context.UserClaims.ResetAsync(cancellationToken);
            await context.Users.ResetAsync(cancellationToken);
        }
    }
}
