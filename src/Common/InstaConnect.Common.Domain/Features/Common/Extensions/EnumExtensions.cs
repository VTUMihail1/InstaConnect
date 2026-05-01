namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class EnumExtensions
{
	extension(Enum @enum)
	{
		public bool IsEmpty()
		{
			return @enum == default;
		}

		public string GetName()
		{
			return @enum.ToString();
		}
	}
}
