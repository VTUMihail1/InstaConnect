namespace InstaConnect.Common.Presentation.Binders.FromClaim;

public class FromClaimValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        context.ValueProviders.Add(new FromClaimValueProvider(
          FromClaimBindingSource.Claim,
          context.ActionContext.HttpContext.User));

        return Task.CompletedTask;
    }
}
