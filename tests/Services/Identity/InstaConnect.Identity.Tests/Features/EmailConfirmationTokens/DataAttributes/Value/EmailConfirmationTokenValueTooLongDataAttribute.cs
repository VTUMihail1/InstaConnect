namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class EmailConfirmationTokenValueTooLongDataAttribute : TooLongStringDataAttribute
{
	public EmailConfirmationTokenValueTooLongDataAttribute()
		: base(EmailConfirmationTokenConfigurations.ValueMaxLength)
	{
	}
}
