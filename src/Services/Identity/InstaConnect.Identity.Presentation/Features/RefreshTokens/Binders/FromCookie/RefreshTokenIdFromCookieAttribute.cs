using InstaConnect.Common.Presentation.Binders.FromCookie;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Binders.FromCookie;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public sealed class RefreshTokenIdFromCookieAttribute : FromCookieAttribute
{
    public RefreshTokenIdFromCookieAttribute() : base(RefreshTokenCookieKeys.Id)
    {
    }
}
