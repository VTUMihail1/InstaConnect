namespace InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class RefreshTokenValueTooShortDataAttribute : TooShortStringDataAttribute
{
	public RefreshTokenValueTooShortDataAttribute()
		: base(RefreshTokenConfigurations.ValueMinLength)
	{
	}
}
