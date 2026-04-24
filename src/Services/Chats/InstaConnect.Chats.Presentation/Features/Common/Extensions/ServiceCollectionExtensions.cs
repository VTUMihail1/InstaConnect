using InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Presentation.Features.Chats.Extensions;
using InstaConnect.Chats.Presentation.Features.Users.Extensions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Extensions;

namespace InstaConnect.Chats.Presentation.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration)
        {
            serviceCollection
                .AddUserServices()
                .AddChatServices()
                .AddChatMessageServices();

            serviceCollection
                .AddServicesWithMatchingInterfaces(ChatsPresentationReference.Assembly)
                .AddApiControllers()
                .AddMapper(ChatsPresentationReference.Assembly, CommonPresentationReference.Assembly)
                .AddAuthorizationPolicies()
                .AddCorsPolicies(configuration)
                .AddRateLimiterPolicies()
                .AddExceptionHandler();

            return serviceCollection;
        }
    }
}
