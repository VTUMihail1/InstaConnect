using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Empty;

namespace InstaConnect.Common.Tests.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SortOrderEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<CommonSortOrder>
{
    public SortOrderEmptyWithMessageDataAttribute() : base(CommonErrorMessages.GetSortOrderEmpty())
    {

    }
}
