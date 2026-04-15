using NSubstitute;

namespace InstaConnect.Common.Tests.Utilities;

public static class Mocker
{
    public static T Mock<T>()
        where T : class
    {
        return Substitute.For<T>();
    }
}
