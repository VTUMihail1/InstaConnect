using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Features.Observability.Extensions;
using InstaConnect.Common.Infrastructure.Features.Observability.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddOpenTelemetry(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection.AddValidatedOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);
            var options = configuration.GetOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);

            serviceCollection.AddOpenTelemetry()
                  .ConfigureResource(r => r.AddService(webHostEnvironment.ApplicationName))
                  .WithTracing(t => t
                      .AddAspNetCoreInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddRedisInstrumentation()
                      .AddMassTransitInstrumentation()
                      .AddOtlpExporter(o => o.Endpoint = new Uri(options.Endpoint)))
                  .WithMetrics(m => m
                      .AddAspNetCoreInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddMassTransitInstrumentation()
                      .AddOtlpExporter(o => o.Endpoint = new Uri(options.Endpoint)));

            return serviceCollection;
        }
    }
}
