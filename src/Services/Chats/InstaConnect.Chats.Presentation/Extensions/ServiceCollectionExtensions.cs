using InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Presentation.Features.Chats.Extensions;
using InstaConnect.Chats.Presentation.Features.Users.Extensions;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Chats.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddUserServices()
            .AddChatServices()
            .AddChatMessageServices();

        serviceCollection
            .AddServicesWithMatchingInterfaces(ChatPresentationReference.Assembly)
            .AddApiControllers()
            .AddMapper(ChatPresentationReference.Assembly, CommonPresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        return serviceCollection;
    }
}
