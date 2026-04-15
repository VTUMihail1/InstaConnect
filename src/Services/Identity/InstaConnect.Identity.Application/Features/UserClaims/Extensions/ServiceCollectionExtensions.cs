namespace InstaConnect.Identity.Application.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddUserClaimServices()
        {
            return serviceCollection;
        }
    }
}
