using InstaConnect.Common.Tests.Utilities.Types.Strings.DifferentCase;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
