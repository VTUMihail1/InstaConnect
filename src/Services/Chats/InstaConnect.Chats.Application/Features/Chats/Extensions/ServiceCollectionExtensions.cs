namespace InstaConnect.Chats.Application.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddChatServices()
        {
            return serviceCollection;
        }
    }
}
