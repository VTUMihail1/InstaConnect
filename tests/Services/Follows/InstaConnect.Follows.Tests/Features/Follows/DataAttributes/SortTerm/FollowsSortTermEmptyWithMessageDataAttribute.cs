namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortTermEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<FollowsSortTerm>;
