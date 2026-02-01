using Mapster;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenAddedEventRequest>()
            .ConstructUsing(src => new(
                src.User.Adapt<UserEventRequest>(),
                src.Adapt<ForgotPasswordTokenEventRequest>()));

        config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.Value,
                src.ExpiresAtUtc,
                src.CreatedAtUtc));
    }
}
