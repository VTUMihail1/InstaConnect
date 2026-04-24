using Microsoft.Net.Http.Headers;

namespace InstaConnect.Common.Presentation.Tests.Features.Utilities;

public static class CookieExtensions
{
    extension(ICollection<SetCookieHeaderValue> cookies)
    {
        public SetCookieHeaderValue GetCookie(string key)
        {
            return cookies.Single(a => a.Name == key);
        }
    }

    extension(SetCookieHeaderValue cookie)
    {
        public string GetStringValue()
        {
            return cookie.Value.ToString();
        }
    }
}
