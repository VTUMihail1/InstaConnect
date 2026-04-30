namespace InstaConnect.Chats.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
