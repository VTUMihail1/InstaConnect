namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
public class PostCommentLikeTestRoutes
{
    public const string Default = "api/v1/post-comment-likes";

    public const string GetAll = "api/v1/post-comment-likes?&userId={0}&userName={1}&postCommentId={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

    public const string Id = "api/v1/post-comment-likes/{0}";
}
