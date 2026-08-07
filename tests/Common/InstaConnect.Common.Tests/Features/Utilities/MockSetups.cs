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

		public void ReturnsResponse<TArg1>(Func<TArg1, TResponse> func)
		{
			response.Returns(a => func(a.Arg<TArg1>()));
		}

		public void ReturnsResponse<TArg1, TArg2>(Func<TArg1, TArg2, TResponse> func)
		{
			response.Returns(a => func(a.Arg<TArg1>(), a.Arg<TArg2>()));
		}
	}

	extension<TResponse>(Task<TResponse> response)
	{
		public void ReturnsTaskResponse(TResponse returnThis)
		{
			response.Returns(returnThis);
		}

		public void ReturnsTaskResponse<TArg1>(Func<TArg1, TResponse> func)
		{
			response.Returns(a => func(a.Arg<TArg1>()));
		}

		public void ReturnsTaskResponse<TArg1, TArg2>(Func<TArg1, TArg2, TResponse> func)
		{
			response.Returns(a => func(a.Arg<TArg1>(), a.Arg<TArg2>()));
		}
	}
}
