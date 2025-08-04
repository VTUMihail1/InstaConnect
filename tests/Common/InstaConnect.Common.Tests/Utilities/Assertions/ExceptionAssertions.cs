using FluentAssertions;

using InstaConnect.Common.Exceptions;

namespace InstaConnect.Common.Tests.Utilities.Assertions;

public static class ExceptionAssertions
{
    public static async Task ShouldThrowAsync<TException>(this Func<Task> action, string message)
        where TException : Exception
    {
        await action.Should().ThrowAsync<TException>().WithMessage(message);
    }

    public static async Task ShouldThrowInvalidValidationExceptionAsync(this Func<Task> action, string message)
    {
        await action.ShouldThrowAsync<InvalidValidationException>(message);
    }
}
