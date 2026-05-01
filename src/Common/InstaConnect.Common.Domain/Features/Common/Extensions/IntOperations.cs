namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class IntOperations
{
	extension(int value)
	{
		public int Increment()
		{
			return value + 1;
		}

		public int Decrement()
		{
			return value - 1;
		}
	}
}
