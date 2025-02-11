namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
public class UserTestRoutes
{
    public const string Default = "api/v1/users";

    public const string GetAll = "api/v1/users?userName={0}&firstName={1}&lastName={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

    public const string Id = "api/v1/users/{0}";

    public const string Current = "api/v1/users/current";

    public const string CurrentDetailed = "api/v1/users/current/detailed";

    public const string IdDetailed = "api/v1/users/{0}/detailed";

    public const string Name = "api/v1/users/by-name/{0}";

    public const string Login = "api/v1/users/login";
}
