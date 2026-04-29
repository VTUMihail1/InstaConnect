using HealthChecks.UI.Client;

using InstaConnect.Common.Presentation.Features.Controllers.Utilities;

using Microsoft.AspNetCore.Builder;

namespace InstaConnect.Common.Presentation.Features.Controllers.Extensions;

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

			webApplication.MapHealthChecks(HealthCheckEndpoint, new()
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

			return webApplication;
		}
	}
}
