namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ForgotPasswordTokenValueTooLongDataAttribute : TooLongStringDataAttribute
{
    public ForgotPasswordTokenValueTooLongDataAttribute()
        : base(ForgotPasswordTokenConfigurations.ValueMaxLength)
    {
    }
}
