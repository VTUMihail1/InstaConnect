namespace InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.CreatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class RefreshTokenCreatedAtUtcEmptyWithMessageDataAttribute : EmptyDateTimeOffsetWithMessageDataAttribute;
