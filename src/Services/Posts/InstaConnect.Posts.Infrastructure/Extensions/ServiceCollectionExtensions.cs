using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Extensions;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Posts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddUserServices()
            .AddPostServices()
            .AddPostLikeServices()
            .AddPostCommentServices()
            .AddPostCommentLikeServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddMapper(PostInfrastructureReference.Assembly)
            .AddServicesWithMatchingInterfaces(PostInfrastructureReference.Assembly)
            .AddMongoDbContext()
            .AddUnitOfWork()
            .AddRabbitMQ(configuration, PostInfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
