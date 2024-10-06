using InstaConnect.Posts.Business.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Business.Features.PostComments.Extensions;
using InstaConnect.Posts.Business.Features.PostLikes.Extensions;
using InstaConnect.Posts.Business.Features.Posts.Extensions;
using InstaConnect.Posts.Business.Features.Users.Extensions;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddValidators(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly);

        return serviceCollection;
    }
}
