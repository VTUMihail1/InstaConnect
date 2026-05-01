namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class EmailConfirmationTokenValueTooShortDataAttribute : TooShortStringDataAttribute
{
	public EmailConfirmationTokenValueTooShortDataAttribute()
		: base(EmailConfirmationTokenConfigurations.ValueMinLength)
	{
	}
}
