namespace InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

public static class UserClaimRoutes
{
	public const string Resource = "api/v{version:apiVersion}/users/{id}/claims";

	public const string Id = "{claim}";

	public const string Version1 = "1.0";
}
