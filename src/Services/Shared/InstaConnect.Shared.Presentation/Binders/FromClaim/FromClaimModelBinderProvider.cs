using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Shared.Presentation.Binders.FromClaim;

public class FromClaimModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var attribute = context
            .Metadata
            .ValidatorMetadata
            .OfType<FromClaimAttribute>()
            .FirstOrDefault();

        if (attribute == null)
        {
            return null!;
        }

        return new FromClaimModelBinder(attribute.ClaimType);
    }
}


