using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Empty;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderEmptyDataAttribute : EmptyEnumDataAttribute<SortOrder>
{
}
