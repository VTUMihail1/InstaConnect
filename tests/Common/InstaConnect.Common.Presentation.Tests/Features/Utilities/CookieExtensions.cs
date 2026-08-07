using InstaConnect.Common.Domain.Features.Common.Extensions;

using Microsoft.Net.Http.Headers;

namespace InstaConnect.Common.Presentation.Tests.Features.Utilities;

public static class CookieExtensions
{
	extension(SetCookieHeaderValue cookie)
	{
		public string GetStringValue()
		{
			return cookie.Value.ToString();
		}

		public bool IsEmpty()
		{
			return cookie.GetStringValue().IsNullOrEmptyOrWhiteSpace();
		}
	}
}
