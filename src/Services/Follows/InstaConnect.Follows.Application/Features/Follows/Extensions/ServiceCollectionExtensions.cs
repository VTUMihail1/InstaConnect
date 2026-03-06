namespace InstaConnect.Follows.Application.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddFollowServices()
        {
            return serviceCollection;
        }
    }
}
