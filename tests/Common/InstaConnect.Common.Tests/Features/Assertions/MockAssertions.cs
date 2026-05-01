using NSubstitute;

namespace InstaConnect.Common.Tests.Features.Assertions;

public static class MockAssertions
{
	extension<T>(T substitute)
		where T : class
	{
		public T ShouldHaveReceived(int numberOfCalls)
		{
			return substitute.Received(numberOfCalls);
		}

		public T ShouldHaveReceivedOne()
		{
			return substitute.ShouldHaveReceived(1);
		}
	}
}
