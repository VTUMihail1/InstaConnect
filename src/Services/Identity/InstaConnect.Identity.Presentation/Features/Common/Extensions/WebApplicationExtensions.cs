using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Extensions;
using InstaConnect.Common.Presentation.Features.Seedings.Extensions;

namespace InstaConnect.Identity.Presentation.Features.Common.Extensions;

internal static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public async Task<WebApplication> UsePresentationAsync(CancellationToken cancellationToken = default)
		{
			return await application
				.UseConfiguredCors()
				.UseRequestRateLimiting()
				.UseSecurity()
				.MapApiEndpoints()
				.UseGlobalExceptionHandling()
				.MapHealthCheckEndpoints()
				.UseDatabaseSeedingAsync(cancellationToken);
		}
	}
}
