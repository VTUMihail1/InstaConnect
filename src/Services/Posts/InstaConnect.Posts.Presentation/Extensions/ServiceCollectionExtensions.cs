using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.PostComments.Extensions;
using InstaConnect.Posts.Presentation.Features.PostLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Extensions;
using InstaConnect.Posts.Presentation.Features.Users.Extensions;
using InstaConnect.Shared.Common.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddServicesWithMatchingInterfaces(PresentationReference.Assembly)
            .AddApiControllers()
            .AddMapper(PresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        return serviceCollection;
    }
}
