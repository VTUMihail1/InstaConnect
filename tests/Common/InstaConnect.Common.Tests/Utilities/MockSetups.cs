using FluentValidation.TestHelper;

using NSubstitute;

namespace InstaConnect.Common.Tests.Utilities;

public static class MockSetups
{
    extension<TResponse>(TResponse response)
    {
        public void ReturnsResponse(TResponse returnThis)
        {
            response.Returns(returnThis);
        }
    }

    extension<TResponse>(Task<TResponse> response)
        where TResponse : class?
    {
        public void ReturnsResponse(TResponse returnThis)
        {
            response.Returns(returnThis);
        }
    }

    extension<T>(T obj)
        where T : class
    {
        public void WhenDo(Action<T> setup, Action callback)
        {
            obj.When(setup).Do(_ => callback());
        }
    }
}
