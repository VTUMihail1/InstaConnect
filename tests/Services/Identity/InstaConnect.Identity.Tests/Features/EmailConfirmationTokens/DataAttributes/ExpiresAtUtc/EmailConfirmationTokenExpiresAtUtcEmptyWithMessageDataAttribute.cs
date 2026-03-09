namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.ExpiresAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class EmailConfirmationTokenExpiresAtUtcEmptyWithMessageDataAttribute : EmptyDateTimeOffsetWithMessageDataAttribute;
