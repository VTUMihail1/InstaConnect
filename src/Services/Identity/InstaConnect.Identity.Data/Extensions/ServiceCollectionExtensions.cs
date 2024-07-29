﻿using InstaConnect.Identity.Data.Features.Tokens.Extensions;
using InstaConnect.Identity.Data.Features.UserClaims.Extensions;
using InstaConnect.Identity.Data.Features.Users.Extensions;
using InstaConnect.Identity.Data.Helpers;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddTokenServices()
            .AddUserClaimServices()
            .AddUserServices();

        serviceCollection
            .AddDatabaseContext<IdentityContext>(configuration);

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddCaching(configuration)
            .AddUnitOfWork<IdentityContext>();

        return serviceCollection;
    }
}
