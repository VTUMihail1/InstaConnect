using FluentValidation.TestHelper;

using NSubstitute;

namespace InstaConnect.Common.Tests.Features.Utilities;

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
		public void ReturnsTaskResponse(TResponse returnThis)
		{
			response.Returns(returnThis);
		}
	}
}
