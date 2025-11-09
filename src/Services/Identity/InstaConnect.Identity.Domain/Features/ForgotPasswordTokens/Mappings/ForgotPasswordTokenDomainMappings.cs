using Mapster;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenAddedEventRequest>()
            .ConstructUsing(fpt => new(
                fpt.Id,
                fpt.Value,
                fpt.ExpiresAt));
    }
}
