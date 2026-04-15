namespace InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class RefreshTokenValueTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public RefreshTokenValueTooLongWithMessageDataAttribute()
        : base(RefreshTokenConfigurations.ValueMaxLength)
    {
    }
}
