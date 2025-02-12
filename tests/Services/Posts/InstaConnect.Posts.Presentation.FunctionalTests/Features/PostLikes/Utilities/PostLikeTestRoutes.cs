namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Utilities;
public class PostLikeTestRoutes
{
    public const string Default = "api/v1/post-likes";

    public const string GetAll = "api/v1/post-likes?&userId={0}&userName={1}&postId={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

    public const string Id = "api/v1/post-likes/{0}";
}
