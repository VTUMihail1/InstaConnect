using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Repositories;
using InstaConnect.Shared.Data;
using InstaConnect.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDbContext<PostsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection
            .AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork(sp.GetRequiredService<PostsContext>()))
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostLikeRepository, PostLikeRepository>()
            .AddScoped<IPostCommentRepository, PostCommentRepository>()
            .AddScoped<IPostCommentLikeRepository, PostCommentLikeRepository>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<PostsContext>();

        return serviceCollection;
    }
}
