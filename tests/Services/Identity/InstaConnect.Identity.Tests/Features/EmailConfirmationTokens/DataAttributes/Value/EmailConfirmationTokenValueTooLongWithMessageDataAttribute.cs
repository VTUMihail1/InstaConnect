namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class EmailConfirmationTokenValueTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public EmailConfirmationTokenValueTooLongWithMessageDataAttribute()
        : base(EmailConfirmationTokenConfigurations.ValueMaxLength)
    {
    }
}
