using InstaConnect.Common.Infrastructure.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Gateway.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection
                .AddObservability(configuration, webHostEnvironment)
                .AddJwtBearer(configuration);

            return serviceCollection;
        }
    }
}
