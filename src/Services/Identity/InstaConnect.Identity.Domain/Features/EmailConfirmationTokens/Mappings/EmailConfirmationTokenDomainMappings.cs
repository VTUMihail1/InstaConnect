using Mapster;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenAddedEventRequest>()
            .ConstructUsing(ect => new(
                ect.Id,
                ect.Value,
                ect.ExpiresAt));
    }
}
