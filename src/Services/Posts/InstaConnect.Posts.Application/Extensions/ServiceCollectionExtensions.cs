using InstaConnect.Posts.Business.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Business.Features.PostComments.Extensions;
using InstaConnect.Posts.Business.Features.PostLikes.Extensions;
using InstaConnect.Posts.Business.Features.Posts.Extensions;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddValidators(currentAssembly);

        return serviceCollection;
    }
}
