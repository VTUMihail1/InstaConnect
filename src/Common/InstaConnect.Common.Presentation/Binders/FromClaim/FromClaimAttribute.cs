namespace InstaConnect.Common.Presentation.Binders.FromClaim;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public sealed class FromClaimAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
    public FromClaimAttribute(string name)
    {
        Name = name;
    }

    public BindingSource BindingSource => FromClaimBindingSource.Claim;

    public string Name { get; }
}
