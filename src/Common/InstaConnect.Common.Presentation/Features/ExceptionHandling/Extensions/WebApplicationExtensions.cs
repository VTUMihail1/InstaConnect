using Microsoft.AspNetCore.Builder;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication webApplication)
    {
        public WebApplication UseGlobalExceptionHandling()
        {
            webApplication.UseExceptionHandler();

            return webApplication;
        }
    }
}
