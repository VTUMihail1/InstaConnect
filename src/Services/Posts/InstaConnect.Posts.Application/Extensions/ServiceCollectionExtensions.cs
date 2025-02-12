using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Application.Features.PostComments.Extensions;
using InstaConnect.Posts.Application.Features.PostLikes.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Extensions;
using InstaConnect.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Extensions;

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
