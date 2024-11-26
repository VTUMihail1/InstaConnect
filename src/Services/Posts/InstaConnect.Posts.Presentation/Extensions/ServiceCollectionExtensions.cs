using InstaConnect.Follows.Web.Features.Users.Extensions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Business.Features.PostComments.Extensions;
using InstaConnect.Posts.Business.Features.PostLikes.Extensions;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Web.Features.PostComments.Extensions;
using InstaConnect.Posts.Web.Features.PostLikes.Extensions;
using InstaConnect.Posts.Web.Features.Posts.Extensions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Posts.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddApiControllers()
            .AddMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddVersioning()
            .AddCurrentUserContext()
            .AddExceptionHandler();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
