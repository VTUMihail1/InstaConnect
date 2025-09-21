using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Binders.FromCookie;

public class FromCookieValueProvider : BindingSourceValueProvider
{
    public FromCookieValueProvider(BindingSource bindingSource, IRequestCookieCollection cookies) : base(bindingSource)
    {
        Cookies = cookies;
    }

    private IRequestCookieCollection Cookies { get; }

    public override bool ContainsPrefix(string prefix)
    {
        return Cookies.ContainsKey(prefix);
    }

    public override ValueProviderResult GetValue(string key)
    {
        return Cookies.TryGetValue(key, out var value) ? new ValueProviderResult(value) : ValueProviderResult.None;
    }
}
