using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Helpers;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddEmailConfirmationTokenServices()
        {
            serviceCollection.AddScoped<IEmailConfirmationTokenTemplateFactory, EmailConfirmationTokenTemplateFactory>();

            return serviceCollection;
        }
    }
}
