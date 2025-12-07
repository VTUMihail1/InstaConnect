using Mapster;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.Value,
                src.ExpiresAtUtc,
                src.CreatedAtUtc));
    }
}
