using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<SortOrder>
{
    public SortOrderEmptyWithMessageDataAttribute() : base(SortOrder.None, CommonErrorMessages.GetSortOrderEmpty())
    {
    }
}
