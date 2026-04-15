namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameEmptyDataAttribute : EmptyStringDataAttribute
{
}
