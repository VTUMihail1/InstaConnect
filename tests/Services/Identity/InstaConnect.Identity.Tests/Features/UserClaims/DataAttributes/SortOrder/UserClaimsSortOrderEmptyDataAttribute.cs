using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimsSortOrderEmptyDataAttribute : EmptyEnumDataAttribute<CommonSortOrder>;
