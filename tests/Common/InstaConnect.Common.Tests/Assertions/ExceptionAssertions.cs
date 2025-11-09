using FluentAssertions;

using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Common.Tests.Assertions;

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
