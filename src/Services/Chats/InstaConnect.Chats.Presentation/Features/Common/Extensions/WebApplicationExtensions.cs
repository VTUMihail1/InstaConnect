using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Chats.Presentation.Features.Common.Extensions;

public static class WebApplicationExtensions
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
