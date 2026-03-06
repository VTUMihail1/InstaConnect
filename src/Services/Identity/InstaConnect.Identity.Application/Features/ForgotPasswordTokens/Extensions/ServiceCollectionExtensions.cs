namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddForgotPasswordTokenServices()
        {
            return serviceCollection;
        }
    }
}
