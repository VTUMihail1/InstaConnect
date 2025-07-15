using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderEmptyDataAttribute : EmptyEnumDataAttribute<SortOrder>
{
    public SortOrderEmptyDataAttribute() : base(SortOrder.None)
    {
    }
}
