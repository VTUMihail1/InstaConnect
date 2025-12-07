using FluentAssertions;

namespace InstaConnect.Common.Tests.Assertions;

public static class ExceptionAssertions
{
    public static async Task ShouldThrowAsync<TException>(
        this Func<Task> action,
        string message,
        Action<TException>? additionalAssertions = null)
        where TException : Exception
    {
        var exception = await action.Should().ThrowAsync<TException>().WithMessage(message);

        additionalAssertions?.Invoke(exception.Which);
    }
}
