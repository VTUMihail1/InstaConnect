using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;

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
