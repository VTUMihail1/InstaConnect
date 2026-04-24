using FluentAssertions;

namespace InstaConnect.Common.Tests.Features.Assertions;

public static class ExceptionAssertions
{
    extension(Func<Task> action)
    {
        public async Task ShouldThrowAsync<TException>(string message, Action<TException>? additionalAssertions = null)
            where TException : Exception
        {
            var exception = await action.Should().ThrowAsync<TException>().WithMessage(message);

            additionalAssertions?.Invoke(exception.Which);
        }
    }
}
