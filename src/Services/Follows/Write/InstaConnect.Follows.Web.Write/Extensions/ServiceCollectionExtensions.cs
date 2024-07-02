﻿using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Follows.Web.Write.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddJwtBearer(configuration)
            .AddApiControllers()
            .AddAutoMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddVersioning()
            .AddExceptionHandler()
            .AddCurrentUserContext();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
