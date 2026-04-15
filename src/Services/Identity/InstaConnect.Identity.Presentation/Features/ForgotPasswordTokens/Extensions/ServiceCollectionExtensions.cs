namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Extensions;

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
