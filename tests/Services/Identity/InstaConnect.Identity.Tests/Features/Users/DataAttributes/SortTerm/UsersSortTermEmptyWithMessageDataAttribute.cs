namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<UsersSortTerm>;
