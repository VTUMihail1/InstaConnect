using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Empty;

namespace InstaConnect.Common.Tests.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderEmptyDataAttribute : EmptyEnumDataAttribute<SortOrder>
{
}
