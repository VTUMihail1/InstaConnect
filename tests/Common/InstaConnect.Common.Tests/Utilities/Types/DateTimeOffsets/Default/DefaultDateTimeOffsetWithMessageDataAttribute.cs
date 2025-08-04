using InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.DateTimeOffsets.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultDateTimeOffsetWithMessageDataAttribute : DateTimeOffsetWithMessageDataAttribute
{
    protected DefaultDateTimeOffsetWithMessageDataAttribute(string message)
        : base(new DefaultDateTimeOffsetTransformer(), message)
    {
    }
}
