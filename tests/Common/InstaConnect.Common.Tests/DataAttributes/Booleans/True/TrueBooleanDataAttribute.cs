using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Booleans.True;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TrueBooleanDataAttribute : BooleanDataAttribute
{
    protected TrueBooleanDataAttribute() : base(new TrueBooleanTransformer())
    {

    }
}
