using InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyDateTimeOffsetDataAttribute : DateTimeOffsetDataAttribute
{
    protected EmptyDateTimeOffsetDataAttribute() : base(new EmptyDateTimeOffsetTransformer())
    {

    }
}
