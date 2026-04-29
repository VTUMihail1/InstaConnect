using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

using Microsoft.Net.Http.Headers;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenCookieExtensions
{
	extension(ICollection<SetCookieHeaderValue> cookies)
	{
		public SetCookieHeaderValue GetId()
		{
			return cookies.Single(a => a.Name == RefreshTokenCookieKeys.Id);
		}

		public SetCookieHeaderValue GetValue()
		{
			return cookies.Single(a => a.Name == RefreshTokenCookieKeys.Value);
		}
	}
}
