using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Shared.Presentation.Binders.FromClaim;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FromClaimAttribute : Attribute, IBindingSourceMetadata
{
    public string ClaimType { get; }

    public FromClaimAttribute(string claimType)
    {
        ClaimType = claimType;
    }

    public BindingSource BindingSource => BindingSource.Custom;
}


