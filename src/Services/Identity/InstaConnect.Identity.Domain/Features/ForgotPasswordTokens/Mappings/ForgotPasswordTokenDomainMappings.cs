using Mapster;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ForgotPasswordTokenIdEventPayload>(),
                src.ExpiresAtUtc));

        config.NewConfig<ForgotPasswordTokenId, ForgotPasswordTokenIdEventPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdEventPayload>(),
                src.Value));
    }
}
