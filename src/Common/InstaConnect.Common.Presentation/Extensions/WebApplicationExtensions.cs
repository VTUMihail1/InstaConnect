using HealthChecks.UI.Client;

using InstaConnect.Common.Presentation.Utilities;

using Microsoft.AspNetCore.Builder;

namespace InstaConnect.Common.Presentation.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication webApplication)
    {
        public WebApplication UseConfiguredCors()
        {
            webApplication.UseCors(CorsPolicies.SpecificOrigins);

            return webApplication;
        }

        public WebApplication UseRequestRateLimiting()
        {
            webApplication.UseRateLimiter();

            return webApplication;
        }

        public WebApplication UseSecurity()
        {
            webApplication.UseAuthentication();
            webApplication.UseAuthorization();

            return webApplication;
        }

        public WebApplication MapApiEndpoints()
        {
            webApplication.MapControllers();

            return webApplication;
        }

        public WebApplication MapHealthCheckEndpoints()
        {
            const string HealthCheckEndpoint = "/healthz";

            webApplication.MapHealthChecks(HealthCheckEndpoint);

            return webApplication;
        }

        public WebApplication UseGlobalExceptionHandling()
        {
            webApplication.UseExceptionHandler();

            return webApplication;
        }
    }
}
