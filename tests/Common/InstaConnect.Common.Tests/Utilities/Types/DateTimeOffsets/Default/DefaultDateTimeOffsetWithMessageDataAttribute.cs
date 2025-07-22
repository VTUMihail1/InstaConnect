using InstaConnect.Common.Tests.Utilities.Types.DateTimes.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultDateTimeOffsetWithMessageDataAttribute : DateTimeOffsetWithMessageDataAttribute
{
    protected DefaultDateTimeOffsetWithMessageDataAttribute(string message)
        : base(new DefaultDateTimeOffsetTransformer(), message)
    {

    }
}

