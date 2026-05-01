namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.UpdatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserUpdatedAtUtcEmptyDataAttribute : EmptyDateTimeOffsetDataAttribute;
