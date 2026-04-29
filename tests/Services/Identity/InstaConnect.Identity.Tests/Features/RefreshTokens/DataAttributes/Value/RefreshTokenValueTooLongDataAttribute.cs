namespace InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class RefreshTokenValueTooLongDataAttribute : TooLongStringDataAttribute
{
	public RefreshTokenValueTooLongDataAttribute()
		: base(RefreshTokenConfigurations.ValueMaxLength)
	{
	}
}
