using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;
using InstaConnect.Common.Tests.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.DataAttributes.Strings.Empty;

namespace InstaConnect.Common.Tests.DataAttributes.Booleans.False;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FalseBooleanDataAttribute : BooleanDataAttribute
{
    protected FalseBooleanDataAttribute() : base(new FalseBooleanTransformer())
    {

    }
}
