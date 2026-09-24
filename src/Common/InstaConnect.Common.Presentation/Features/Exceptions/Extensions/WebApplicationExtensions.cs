using Microsoft.AspNetCore.Builder;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication webApplication)
	{
		public WebApplication UseExceptions()
		{
			webApplication.UseExceptionHandler();

			return webApplication;
		}
	}
}
