namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class EnumExtensions
{
	extension(Enum @enum)
	{
		public string GetName()
		{
			return @enum.ToString();
		}
	}
}
