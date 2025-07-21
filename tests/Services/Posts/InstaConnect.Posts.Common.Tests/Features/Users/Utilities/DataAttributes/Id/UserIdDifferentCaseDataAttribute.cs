using InstaConnect.Common.Tests.Utilities.Types.Strings.DifferentCase;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
