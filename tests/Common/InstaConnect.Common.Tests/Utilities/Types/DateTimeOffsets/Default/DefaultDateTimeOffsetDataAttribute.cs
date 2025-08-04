using InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultDateTimeOffsetDataAttribute : DateTimeOffsetDataAttribute
{
    protected DefaultDateTimeOffsetDataAttribute() : base(new DefaultDateTimeOffsetTransformer())
    {
    }
}
