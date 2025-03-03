﻿using InstaConnect.Emails.Infrastructure.Features.Emails.Extensions;
using InstaConnect.Shared.Common.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddEmailServices(configuration);

        serviceCollection
            .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
            .AddRabbitMQ(configuration, InfrastructureReference.Assembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
