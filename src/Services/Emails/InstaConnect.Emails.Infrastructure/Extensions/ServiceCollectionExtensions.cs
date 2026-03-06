using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection
                .AddEmailServices(configuration);

            serviceCollection
                .AddObservability(configuration, webHostEnvironment)
                .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
                .AddRabbitMQ(configuration, InfrastructureReference.Assembly)
                .AddJwtBearer(configuration);

            return serviceCollection;
        }
    }
}
