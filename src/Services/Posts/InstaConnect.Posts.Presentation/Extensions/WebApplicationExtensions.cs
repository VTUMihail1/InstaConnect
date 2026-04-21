using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.Extensions;

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
                .UseGlobalExceptionHandling();
        }
    }
}
