using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Features.Common.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication UsePresentation()
		{
			application
				.UseConfiguredCors()
				.UseRequestRateLimiting()
				.UseSecurity()
				.MapApiEndpoints()
				.UseGlobalExceptionHandling()
				.MapHealthCheckEndpoints()
				.MapFollowHub();

			return application;
		}
	}
}
