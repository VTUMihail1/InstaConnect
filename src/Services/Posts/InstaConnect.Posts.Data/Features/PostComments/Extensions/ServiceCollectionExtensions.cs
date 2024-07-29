using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IPostCommentReadRepository, PostCommentReadRepository>()
            .AddScoped<IPostCommentWriteRepository, PostCommentWriteRepository>();

        return serviceCollection;
    }
}
