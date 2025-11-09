using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
    protected EmptyIntWithMessageDataAttribute(string message) : base(new EmptyIntTransformer(), message)
    {
    }
}
