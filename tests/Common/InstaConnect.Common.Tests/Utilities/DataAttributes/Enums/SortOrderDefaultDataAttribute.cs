using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Default;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderDefaultDataAttribute : DefaultEnumDataAttribute<SortOrder>
{
}
