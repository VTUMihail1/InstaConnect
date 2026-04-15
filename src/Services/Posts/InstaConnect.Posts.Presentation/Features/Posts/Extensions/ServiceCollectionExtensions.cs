namespace InstaConnect.Posts.Presentation.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddPostServices()
        {
            return serviceCollection;
        }
    }
}
