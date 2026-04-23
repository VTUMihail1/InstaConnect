using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Application.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddApplication()
        {
            serviceCollection
                .AddUserServices()
                .AddChatServices()
                .AddChatMessageServices();

            serviceCollection
                .AddCQRS(ChatsApplicationReference.Assembly)
                .AddMapper(ChatsApplicationReference.Assembly, CommonApplicationReference.Assembly)
                .AddValidators(ChatsApplicationReference.Assembly);

            return serviceCollection;
        }
    }
}
