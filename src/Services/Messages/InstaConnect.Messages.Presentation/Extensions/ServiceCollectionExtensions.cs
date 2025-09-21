using InstaConnect.Common.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Chats.Presentation.Features.Chats.Extensions;
using InstaConnect.Posts.Presentation.Features.Users.Extensions;
using InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Extensions;

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
            .AddMapper(ChatPresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        return serviceCollection;
    }
}
