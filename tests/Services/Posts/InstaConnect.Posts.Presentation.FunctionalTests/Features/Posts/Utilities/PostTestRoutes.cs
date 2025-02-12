namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;
public class PostTestRoutes
{
    public const string Default = "api/v1/posts";

    public const string GetAll = "api/v1/posts?&userId={0}&userName={1}&title={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

    public const string Id = "api/v1/posts/{0}";
}
