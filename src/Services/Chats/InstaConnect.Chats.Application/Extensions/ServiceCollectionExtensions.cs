using InstaConnect.Common.Domain.Extensions;

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
            .AddMapper(ChatApplicationReference.Assembly, CommonApplicationReference.Assembly)
            .AddValidators(ChatApplicationReference.Assembly);

        return serviceCollection;
    }
}
