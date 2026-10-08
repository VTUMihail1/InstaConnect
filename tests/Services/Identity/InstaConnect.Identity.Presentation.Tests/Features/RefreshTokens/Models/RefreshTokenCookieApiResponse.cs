using Microsoft.Net.Http.Headers;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Models;

public record RefreshTokenCookieApiResponse(SetCookieHeaderValue IdCookie, SetCookieHeaderValue ValueCookie);
