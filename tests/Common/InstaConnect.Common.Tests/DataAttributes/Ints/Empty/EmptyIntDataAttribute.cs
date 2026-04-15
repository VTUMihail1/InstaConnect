using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntDataAttribute : IntDataAttribute
{
    protected EmptyIntDataAttribute() : base(new EmptyIntTransformer())
    {
    }
}
