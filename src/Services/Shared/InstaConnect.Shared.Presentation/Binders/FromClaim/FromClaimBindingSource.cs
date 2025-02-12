using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Shared.Presentation.Binders.FromClaim;

public static class FromClaimBindingSource
{
    public static readonly BindingSource Claim = new(
      "Claim",
      "BindingSource_Claim",
      false,
      true);
}
