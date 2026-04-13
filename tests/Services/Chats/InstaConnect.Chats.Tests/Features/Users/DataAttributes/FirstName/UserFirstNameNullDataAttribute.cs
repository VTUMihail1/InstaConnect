namespace InstaConnect.Chats.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameNullDataAttribute : NullStringDataAttribute
{
}
