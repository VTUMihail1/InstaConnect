using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Helpers;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddForgotPasswordTokenServices()
        {
            serviceCollection.AddScoped<IForgotPasswordTokenTemplateFactory, ForgotPasswordTokenTemplateFactory>();

            return serviceCollection;
        }
    }
}
