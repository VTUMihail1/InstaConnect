namespace InstaConnect.Identity.Presentation.Features.Users.Utilities;

public static class UserRoutes
{
	public const string Resource = "api/v{version:apiVersion}/users";

	public const string Current = "current";

	public const string CurrentDetails = "current/details";

	public const string Id = "{id}";

	public const string IdDetails = "{id}/details";

	public const string Version1 = "1.0";
}
