using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;

using Microsoft.AspNetCore.Http;

using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace InstaConnect.Common.Presentation.Helpers;

public class CookieStore : ICookieStore
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieStore(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetHttpOnly(string key, string value, DateTimeOffset expiresAt)
    {
        var response = _httpContextAccessor.HttpContext?.Response;

        if (response.IsNull())
        {
            return;
        }

        var options = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = expiresAt
        };

        response!.Cookies.Append(key, value, options);
    }

    public void Set(string key, string value, int expireSeconds)
    {
        var response = _httpContextAccessor.HttpContext?.Response;

        if (response.IsNull())
        {
            return;
        }

        var options = new CookieOptions
        {
            HttpOnly = false,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = _dateTimeProvider.GetOffsetUtcNow(expireSeconds)
        };

        response!.Cookies.Append(key, value, options);
    }

    public string? Get(string key)
    {
        var request = _httpContextAccessor.HttpContext?.Request;

        if (request.IsNull())
        {
            return null;
        }

        request!.Cookies.TryGetValue(key, out var value);

        return value;
    }

    public void Delete(string key)
    {
        var response = _httpContextAccessor.HttpContext?.Response;

        if (response.IsNull())
        {
            return;
        }

        response!.Cookies.Delete(key);
    }
}
