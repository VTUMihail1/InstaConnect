namespace InstaConnect.Gateway.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"));

            return serviceCollection;
        }
    }
}
