using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Common.Presentation.Binders.FromCookie;

public static class FromCookieBindingSource
{
    public static readonly BindingSource Instance = new(
        "Cookie",
        "BindingSource_Cookie",
        false,
        true);
}
