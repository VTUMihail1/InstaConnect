using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Common.Presentation.Binders.FromCookie;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public sealed class FromCookieAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
    public FromCookieAttribute(string name)
    {
        Name = name;
    }

    public BindingSource BindingSource => FromCookieBindingSource.Instance;

    public string Name { get; }
}
