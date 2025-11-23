using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Chats.Presentation.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UsePresentation(this WebApplication application)
    {
        return application
            .UseDeveloperDocumentation()
            .UseConfiguredCors()
            .UseRequestRateLimiting()
            .UseSecurity()
            .MapApiEndpoints()
            .UseGlobalExceptionHandling();
    }
}
