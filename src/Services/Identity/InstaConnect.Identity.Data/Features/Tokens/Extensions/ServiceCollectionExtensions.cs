using InstaConnect.Identity.Data.Features.Tokens.Abstractions;
using InstaConnect.Identity.Data.Features.Tokens.Helpers;
using InstaConnect.Identity.Data.Features.Tokens.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Features.Tokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<ITokenWriteRepository, TokenWriteRepository>()
            .AddScoped<ITokenFactory, TokenFactory>()
            .AddScoped<ITokenGenerator, TokenGenerator>();

        return serviceCollection;
    }
}
