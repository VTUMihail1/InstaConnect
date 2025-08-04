using InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Default;
using InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Default;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultDateTimeOffsetDataAttribute : DateTimeOffsetDataAttribute
{
    protected DefaultDateTimeOffsetDataAttribute() : base(new DefaultDateTimeOffsetTransformer())
    {
    }
}
