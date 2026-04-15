namespace InstaConnect.Follows.Presentation.Features.Users.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddUserServices()
        {
            return serviceCollection;
        }
    }
}
