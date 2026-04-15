using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Common.Presentation.Binders.FromCookie;

public class FromCookieValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        var cookies = context.ActionContext.HttpContext.Request.Cookies;

        context.ValueProviders.Add(new FromCookieValueProvider(FromCookieBindingSource.Instance, cookies));

        return Task.CompletedTask;
    }
}
