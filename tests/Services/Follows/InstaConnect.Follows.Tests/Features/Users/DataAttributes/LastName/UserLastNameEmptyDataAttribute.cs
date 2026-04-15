namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameEmptyDataAttribute : EmptyStringDataAttribute
{
}
