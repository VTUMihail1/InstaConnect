using InstaConnect.Data;
using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Factories;
using InstaConnect.Data.Helpers;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddDbContext<InstaConnectContext>(options =>
                 {
                     var connectionString = configuration.GetConnectionString("DefaultConnection");
                     var serverVersion = ServerVersion.AutoDetect(connectionString);
                     options.UseMySql(connectionString, serverVersion);
                 });

            services
                .AddScoped<IDbSeeder, DbSeeder>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAccountManager, AccountManager>()
                .AddScoped<IPostCommentLikeRepository, PostCommentLikeRepository>()
                .AddScoped<IPostLikeRepository, PostLikeRepository>()
                .AddScoped<IPostCommentRepository, PostCommentRepository>()
                .AddScoped<IMessageRepository, MessageRepository>()
                .AddScoped<IFollowRepository, FollowRepository>()
                .AddScoped<ITokenFactory, TokenFactory>()
                .AddScoped<ITokenRepository, TokenRepository>();

            services
                .AddIdentity<User, Role>()
                .AddEntityFrameworkStores<InstaConnectContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
