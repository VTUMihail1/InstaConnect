namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMockFactory
{
    public static IFollowCommandService CreateCommandService()
    {
        return Mocker.Mock<IFollowCommandService>();
    }

    public static IFollowQueryService CreateQueryService()
    {
        return Mocker.Mock<IFollowQueryService>();
    }
}
