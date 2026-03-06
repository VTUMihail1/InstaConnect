using InstaConnect.Common.Presentation.Utilities;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace InstaConnect.Common.Presentation.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication webApplication)
    {
        public WebApplication UseDeveloperDocumentation()
        {
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }

            return webApplication;
        }

        public WebApplication UseConfiguredCors()
        {
            webApplication.UseCors(AppPolicies.CorsPolicy);

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

        public WebApplication UseGlobalExceptionHandling()
        {
            webApplication.UseExceptionHandler();

            return webApplication;
        }
    }
}
