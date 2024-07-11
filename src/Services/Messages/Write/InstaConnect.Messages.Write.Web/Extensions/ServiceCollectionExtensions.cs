﻿using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Messages.Write.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddJwtBearer(configuration)
            .AddApiControllers()
            .AddMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddVersioning()
            .AddCurrentUserContext()
            .AddExceptionHandler();

        serviceCollection.AddSignalR();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
