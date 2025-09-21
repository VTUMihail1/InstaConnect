using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;

using Mapster;

namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ForgotPasswordTokenQueryEntity, ForgotPasswordToken>()
              .ConstructUsing(u => new(
                            u.Id,
                            u.Value,
                            u.ExpiresAt,
                            u.CreatedAt,
                            u.UpdatedAt));
    }
}
