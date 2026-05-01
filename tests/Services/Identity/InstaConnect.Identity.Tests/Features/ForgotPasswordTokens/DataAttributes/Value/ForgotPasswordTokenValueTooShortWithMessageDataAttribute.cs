namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ForgotPasswordTokenValueTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
	public ForgotPasswordTokenValueTooShortWithMessageDataAttribute()
		: base(ForgotPasswordTokenConfigurations.ValueMinLength)
	{
	}
}
