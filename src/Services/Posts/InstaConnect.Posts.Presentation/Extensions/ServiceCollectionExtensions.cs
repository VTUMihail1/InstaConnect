using InstaConnect.Common.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Extensions;
using InstaConnect.PostComments.Presentation.Features.PostComments.Extensions;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Extensions;
using InstaConnect.Posts.Presentation.Features.Users.Extensions;

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
            .AddServicesWithMatchingInterfaces(PostPresentationReference.Assembly)
            .AddApiControllers()
            .AddMapper(PostPresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        return serviceCollection;
    }
}
