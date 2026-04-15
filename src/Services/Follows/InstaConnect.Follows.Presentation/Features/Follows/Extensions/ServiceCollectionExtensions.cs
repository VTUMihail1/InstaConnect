namespace InstaConnect.Follows.Presentation.Features.Follows.Extensions;

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
