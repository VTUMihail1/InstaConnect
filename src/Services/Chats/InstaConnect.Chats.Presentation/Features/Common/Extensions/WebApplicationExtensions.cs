using InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Extensions;

namespace InstaConnect.Chats.Presentation.Features.Common.Extensions;

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
				.UseGlobalExceptionHandling()
				.MapHealthCheckEndpoints()
				.MapChatMessageHub();
		}
	}
}
