using FluentAssertions;

namespace InstaConnect.Common.Tests.Features.Assertions;

public static class ExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowAsync<TException>(string message, CancellationToken cancellationToken)
			where TException : Exception
		{
			await func.Should().ThrowAsync<TException>().WithMessage(message);
		}
	}
}
