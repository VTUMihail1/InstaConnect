namespace InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.ExpiresAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class RefreshTokenExpiresAtUtcEmptyWithMessageDataAttribute : EmptyDateTimeOffsetWithMessageDataAttribute;
