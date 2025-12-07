using FluentValidation.TestHelper;

using NSubstitute;

namespace InstaConnect.Common.Tests.Utilities;

public static class MockSetups
{
    public static void ReturnsResponse<TResponse>(this TResponse response, TResponse returnThis)
        where TResponse : class?
    {
        response.Returns(returnThis);
    }

    public static void ReturnsResponse<TResponse>(this Task<TResponse> response, TResponse returnThis)
        where TResponse : class?
    {
        response.Returns(returnThis);
    }

    public static void WhenDo<T>(this T obj, Action<T> setup, Action callback)
            where T : class
    {
        obj.When(setup).Do(_ => callback());
    }
}
