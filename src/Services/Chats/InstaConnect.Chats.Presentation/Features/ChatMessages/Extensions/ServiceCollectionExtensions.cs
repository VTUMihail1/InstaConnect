namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddChatMessageServices()
        {
            return serviceCollection;
        }
    }
}
