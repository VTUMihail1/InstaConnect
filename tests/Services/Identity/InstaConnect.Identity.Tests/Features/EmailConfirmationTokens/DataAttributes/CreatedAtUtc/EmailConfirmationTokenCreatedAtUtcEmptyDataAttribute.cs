namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.CreatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class EmailConfirmationTokenCreatedAtUtcEmptyDataAttribute : EmptyDateTimeOffsetDataAttribute;
