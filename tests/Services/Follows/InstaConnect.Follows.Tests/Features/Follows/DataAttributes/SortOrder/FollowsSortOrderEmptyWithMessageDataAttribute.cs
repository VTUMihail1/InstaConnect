using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortOrderEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<CommonSortOrder>;
