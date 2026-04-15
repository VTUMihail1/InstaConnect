namespace InstaConnect.Follows.Domain.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddUserServices()
        {
            return serviceCollection;
        }
    }
}
