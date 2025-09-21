using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Application.Features.Chats.Extensions;
using InstaConnect.Users.Application.Features.Users.Extensions;
using InstaConnect.ChatMessages.Application.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddChatServices()
            .AddChatMessageServices();

        serviceCollection
            .AddCQRS(ChatApplicationReference.Assembly)
            .AddMapper(ChatApplicationReference.Assembly)
            .AddValidators(ChatApplicationReference.Assembly);

        return serviceCollection;
    }
}
