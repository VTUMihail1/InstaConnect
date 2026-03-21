namespace InstaConnect.Identity.Presentation.Features.UserClaims.Extensions;

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
