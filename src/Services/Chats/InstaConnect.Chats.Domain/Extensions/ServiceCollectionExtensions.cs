using InstaConnect.Chats.Domain.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Domain.Features.Chats.Extensions;
using InstaConnect.Chats.Domain.Features.Users.Extensions;
using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddChatServices()
            .AddChatMessageServices();

        serviceCollection
            .AddMapper(ChatDomainReference.Assembly)
            .AddServicesWithMatchingInterfaces(ChatDomainReference.Assembly);

        return serviceCollection;
    }
}
