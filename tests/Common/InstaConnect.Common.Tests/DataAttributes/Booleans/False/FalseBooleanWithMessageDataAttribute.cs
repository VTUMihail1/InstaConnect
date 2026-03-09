using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;
using InstaConnect.Common.Tests.DataAttributes.Booleans.True;

namespace InstaConnect.Common.Tests.DataAttributes.Booleans.False;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FalseBooleanWithMessageDataAttribute : BooleanWithMessageDataAttribute
{
    protected FalseBooleanWithMessageDataAttribute() : base(
        new FalseBooleanTransformer(),
        new FalseBooleanMessageTransformer())
    {
    }
}
