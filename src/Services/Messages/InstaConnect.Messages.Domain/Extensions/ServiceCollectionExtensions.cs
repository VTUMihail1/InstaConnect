using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Domain.Extensions;
using InstaConnect.Chats.Domain.Features.Chats.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Extensions;

using Microsoft.Extensions.DependencyInjection;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Extensions;

namespace InstaConnect.Identity.Domain.Extensions;

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
