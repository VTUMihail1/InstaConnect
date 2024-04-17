using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Profiles;
using InstaConnect.Users.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Users.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ITokenService, TokenService>()
                .AddAutoMapper(typeof(UsersBusinessProfile));

            return serviceCollection;
        }
    }
}
