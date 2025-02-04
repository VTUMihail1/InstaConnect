namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
public class PostCommentTestRoutes
{
    public const string Default = "api/v1/post-comments";

    public const string GetAll = "api/v1/post-comments?&userId={0}&userName={1}&postId={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

    public const string Id = "api/v1/post-comments/{0}";
}
