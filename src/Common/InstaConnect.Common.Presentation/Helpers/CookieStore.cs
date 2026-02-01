using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Http;

using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace InstaConnect.Common.Presentation.Helpers;

public class CookieStore : ICookieStore
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieStore(
        IDateTimeProvider dateTimeProvider,
        IHttpContextAccessor httpContextAccessor)
    {
        _dateTimeProvider = dateTimeProvider;
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetHttpOnly(string key, string value, DateTimeOffset expiresAt)
    {
        var response = _httpContextAccessor.HttpContext?.Response;

        if (response == null)
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

        response.Cookies.Append(key, value, options);
    }

    public void Set(string key, string value, int expireSeconds)
    {
        var response = _httpContextAccessor.HttpContext?.Response;

        if (response == null)
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

        response.Cookies.Append(key, value, options);
    }

    public string? Get(string key)
    {
        var request = _httpContextAccessor.HttpContext?.Request;

        if (request == null)
        {
            return null;
        }

        request.Cookies.TryGetValue(key, out var value);

        return value;
    }

    public void Delete(string key)
    {
        var response = _httpContextAccessor.HttpContext?.Response;

        if (response == null)
        {
            return;
        }

        response.Cookies.Delete(key);
    }
}
