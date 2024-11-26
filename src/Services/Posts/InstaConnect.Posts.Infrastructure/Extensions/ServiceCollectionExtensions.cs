using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;
using InstaConnect.Posts.Infrastructure.Helpers;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddDatabaseContext<PostsContext>(configuration);

        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<PostsContext>()
            .AddRabbitMQ(configuration, currentAssembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
