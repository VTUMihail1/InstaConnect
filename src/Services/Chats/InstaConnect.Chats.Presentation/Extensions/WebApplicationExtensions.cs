using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Chats.Presentation.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication application)
    {
        public WebApplication UsePresentation()
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
}
