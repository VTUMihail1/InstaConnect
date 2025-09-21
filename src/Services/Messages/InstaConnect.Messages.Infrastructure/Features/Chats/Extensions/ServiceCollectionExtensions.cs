using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddChatServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IChatByParticipantSortProperty>(ChatInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
