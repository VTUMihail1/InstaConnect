using InstaConnect.Common.Presentation.Utilities;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace InstaConnect.Common.Presentation.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseDeveloperDocumentation(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }

        return webApplication;
    }

    public static WebApplication UseConfiguredCors(this WebApplication webApplication)
    {
        webApplication.UseCors(AppPolicies.CorsPolicy);

        return webApplication;
    }

    public static WebApplication UseRequestRateLimiting(this WebApplication webApplication)
    {
        webApplication.UseRateLimiter();

        return webApplication;
    }

    public static WebApplication UseSecurity(this WebApplication webApplication)
    {
        webApplication.UseAuthentication();
        webApplication.UseAuthorization();

        return webApplication;
    }

    public static WebApplication MapApiEndpoints(this WebApplication webApplication)
    {
        webApplication.MapControllers();

        return webApplication;
    }

    public static WebApplication UseGlobalExceptionHandling(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandler();

        return webApplication;
    }
}
