using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.PostComments.Extensions;
using InstaConnect.Posts.Presentation.Features.PostLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Extensions;
using InstaConnect.Posts.Presentation.Features.Users.Extensions;

namespace InstaConnect.Posts.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration)
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
                .AddMapper(PostPresentationReference.Assembly, CommonPresentationReference.Assembly)
                .AddAuthorizationPolicies()
                .AddCorsPolicies(configuration)
                .AddSwagger()
                .AddRateLimiterPolicies()
                .AddExceptionHandler();

            return serviceCollection;
        }
    }
}
