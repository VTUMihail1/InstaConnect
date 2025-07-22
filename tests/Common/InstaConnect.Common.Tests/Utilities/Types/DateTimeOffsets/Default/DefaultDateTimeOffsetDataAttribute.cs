using InstaConnect.Common.Tests.Utilities.Types.DateTimes.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultDateTimeOffsetDataAttribute : DateTimeOffsetDataAttribute
{
    protected DefaultDateTimeOffsetDataAttribute()
        : base(new DefaultDateTimeOffsetTransformer())
    {
    }
}
