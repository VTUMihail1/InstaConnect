namespace InstaConnect.Identity.Presentation.Features.Users.Utilities;

public static class UserRoutes
{
    public const string Resource = "api/v{version:apiVersion}/users";

    public const string Current = "current";

    public const string CurrentDetailed = "current/detailed";

    public const string Id = "{id}";

    public const string IdDetailed = "{id}/detailed";

    public const string Name = "by-name/{username}";

    public const string Login = "login";

    public const string Version1 = "1.0";
}
