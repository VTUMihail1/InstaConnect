using NSubstitute;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class MockSetups
{
	extension<T>(T substitute) where T : class
	{
		public T ClearCalls()
		{
			substitute.ClearReceivedCalls();

			return substitute;
		}
	}

	extension<TResponse>(TResponse response)
	{
		public void ReturnsResponse(TResponse returnThis)
		{
			response.Returns(returnThis);
		}
	}

	extension<TResponse>(Task<TResponse> response)
	{
		public void ReturnsTaskResponse(TResponse returnThis)
		{
			response.Returns(returnThis);
		}
	}
}
