namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.ExpiresAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ForgotPasswordTokenExpiresAtUtcEmptyDataAttribute : EmptyDateTimeOffsetDataAttribute;
