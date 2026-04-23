using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Identity.Presentation.Features.Common.Extensions;

internal static class WebApplicationExtensions
{
    extension(WebApplication application)
    {
        public WebApplication UsePresentation()
        {
            return application
                .UseConfiguredCors()
                .UseRequestRateLimiting()
                .UseSecurity()
                .MapApiEndpoints()
                .UseGlobalExceptionHandling()
                .MapHealthCheckEndpoints();
        }
    }
}
