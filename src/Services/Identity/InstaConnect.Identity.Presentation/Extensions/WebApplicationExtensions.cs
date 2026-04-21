using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Identity.Presentation.Extensions;

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
                .UseGlobalExceptionHandling();
        }
    }
}
