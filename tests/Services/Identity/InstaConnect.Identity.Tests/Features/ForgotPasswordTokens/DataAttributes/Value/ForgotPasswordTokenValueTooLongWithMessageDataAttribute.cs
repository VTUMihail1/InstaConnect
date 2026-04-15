namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ForgotPasswordTokenValueTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public ForgotPasswordTokenValueTooLongWithMessageDataAttribute()
        : base(ForgotPasswordTokenConfigurations.ValueMaxLength)
    {
    }
}
