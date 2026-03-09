namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.UpdatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserUpdatedAtUtcEmptyWithMessageDataAttribute : EmptyDateTimeOffsetWithMessageDataAttribute;
