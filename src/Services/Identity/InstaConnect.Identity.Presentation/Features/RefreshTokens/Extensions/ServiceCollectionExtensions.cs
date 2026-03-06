namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddRefreshTokenServices()
        {
            return serviceCollection;
        }
    }
}
