namespace InstaConnect.Common.Presentation.Binders.FromCookie;

public static class FromCookieBindingSource
{
    public static readonly BindingSource Instance = new BindingSource(
        "Cookie",
        "BindingSource_Cookie",
        false,
        true);
}
