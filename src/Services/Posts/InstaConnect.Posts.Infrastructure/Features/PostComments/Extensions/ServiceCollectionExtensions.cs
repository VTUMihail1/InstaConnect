using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

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
