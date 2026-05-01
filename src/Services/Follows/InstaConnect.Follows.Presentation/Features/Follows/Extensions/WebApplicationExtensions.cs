using InstaConnect.Follows.Presentation.Features.Follows.Helpers;

namespace InstaConnect.Follows.Presentation.Features.Follows.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication MapFollowHub()
		{
			application.MapHub<FollowHub>(FollowRoutes.Hub);

			return application;
		}
	}
}
