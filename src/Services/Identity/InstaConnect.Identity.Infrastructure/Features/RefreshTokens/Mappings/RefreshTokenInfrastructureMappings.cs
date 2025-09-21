using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;

using Mapster;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Mappings;

internal class RefreshTokenInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RefreshTokenQueryEntity, RefreshToken>()
              .ConstructUsing(u => new(
                            u.Id,
                            u.Value,
                            u.ExpiresAt,
                            u.CreatedAt,
                            u.UpdatedAt));
    }
}
