using InstaConnect.Common.Tests.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.DataAttributes.FormFiles.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullFormFileDataAttribute : FormFileDataAttribute
{
    protected NullFormFileDataAttribute() : base(new NullFormFileTransformer())
    {

    }
}
