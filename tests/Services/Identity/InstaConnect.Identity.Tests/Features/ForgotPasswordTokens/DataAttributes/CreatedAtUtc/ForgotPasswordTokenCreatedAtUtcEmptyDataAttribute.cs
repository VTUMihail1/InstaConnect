namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.CreatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ForgotPasswordTokenCreatedAtUtcEmptyDataAttribute : EmptyDateTimeOffsetDataAttribute;
