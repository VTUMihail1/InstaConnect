using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullFormFileDataAttribute : FormFileDataAttribute
{
    protected NullFormFileDataAttribute() : base(new NullFormFileTransformer())
    {

    }
}
