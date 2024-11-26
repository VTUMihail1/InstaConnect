using InstaConnect.Posts.Data.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Data.Features.PostComments.Extensions;
using InstaConnect.Posts.Data.Features.PostLikes.Extensions;
using InstaConnect.Posts.Data.Features.Posts.Extensions;
using InstaConnect.Posts.Data.Features.Users.Extensions;
using InstaConnect.Posts.Data.Helpers;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Extensions;

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
            .AddMessageBroker(configuration, currentAssembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
