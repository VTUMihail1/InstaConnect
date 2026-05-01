namespace InstaConnect.Chats.Tests.Features.Users.DataAttributes.CreatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserCreatedAtUtcEmptyDataAttribute : EmptyDateTimeOffsetDataAttribute;
