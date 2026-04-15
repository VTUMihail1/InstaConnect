namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimsSortTermEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<UserClaimsSortTerm>;
