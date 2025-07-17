using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Empty;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<SortOrder>
{
    public SortOrderEmptyWithMessageDataAttribute() : base(CommonErrorMessages.GetSortOrderEmpty())
    {
        
    }
}
