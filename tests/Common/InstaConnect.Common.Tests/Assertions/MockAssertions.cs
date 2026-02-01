using NSubstitute;

namespace InstaConnect.Common.Tests.Assertions;

public static class MockAssertions
{
    public static T ShouldHaveReceived<T>(this T substitute, int numberOfCalls) where T : class
    {
        return substitute.Received(numberOfCalls);
    }

    public static T ShouldHaveReceivedOne<T>(this T substitute) where T : class
    {
        return substitute.ShouldHaveReceived(1);
    }
}
