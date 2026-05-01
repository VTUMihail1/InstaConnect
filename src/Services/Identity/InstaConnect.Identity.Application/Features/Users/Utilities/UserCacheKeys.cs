using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Identity.Application.Features.Users.Utilities;

public static class UserCacheKeys
{
	public static string GetCurrent(string currentId)
	{
		const string Format = "get-current-user-{0}";

		return Format.FormatCurrentCulture(currentId);
	}

	public static string GetCurrentDetailed(string currentId)
	{
		const string Format = "get-current-user-detailed-{0}";

		return Format.FormatCurrentCulture(currentId);
	}
}
