namespace InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;

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
