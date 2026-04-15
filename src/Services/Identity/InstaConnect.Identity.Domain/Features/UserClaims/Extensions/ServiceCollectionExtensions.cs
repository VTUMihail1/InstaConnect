namespace InstaConnect.Identity.Domain.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddUserClaimsServices()
        {
            return serviceCollection;
        }
    }
}
