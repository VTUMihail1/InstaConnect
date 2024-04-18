using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Profiles;
using InstaConnect.Users.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InstaConnect.Users.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ITokenService, TokenService>()
                .AddAutoMapper(typeof(UsersBusinessProfile));

            serviceCollection.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            return serviceCollection;
        }
    }
}
