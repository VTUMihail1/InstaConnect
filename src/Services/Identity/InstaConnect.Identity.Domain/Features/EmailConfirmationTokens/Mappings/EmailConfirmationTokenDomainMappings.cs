using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

using Mapster;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<EmailConfirmationTokenIdEventPayload>(),
                src.ExpiresAtUtc));

        config.NewConfig<EmailConfirmationTokenId, EmailConfirmationTokenIdEventPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdEventPayload>(),
                src.Value));
    }
}
