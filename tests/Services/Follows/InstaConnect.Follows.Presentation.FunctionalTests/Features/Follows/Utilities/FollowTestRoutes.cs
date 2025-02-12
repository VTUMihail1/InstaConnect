namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
public class FollowTestRoutes
{
    public const string Default = "api/v1/follows";

    public const string GetAll = "api/v1/follows?followerId={0}&followerName={1}&followingId={2}&followingName={3}&sortOrder={4}&sortPropertyName={5}&page={6}&pageSize={7}";

    public const string Id = "api/v1/follows/{0}";
}
