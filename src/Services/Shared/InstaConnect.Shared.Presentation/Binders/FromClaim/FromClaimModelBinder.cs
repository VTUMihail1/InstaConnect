using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Shared.Presentation.Binders.FromClaim;

public class FromClaimModelBinder : IModelBinder
{
    private readonly string _claimType;

    public FromClaimModelBinder(string claimType)
    {
        _claimType = claimType;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var user = bindingContext.HttpContext.User;

        if (user?.Identity is not ClaimsIdentity identity || !identity.IsAuthenticated)
        {
            return Task.CompletedTask;
        }

        var claim = user.Claims.FirstOrDefault(c => c.Type == _claimType);

        if (claim == null)
        {
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(claim.Value);

        return Task.CompletedTask;
    }
}


