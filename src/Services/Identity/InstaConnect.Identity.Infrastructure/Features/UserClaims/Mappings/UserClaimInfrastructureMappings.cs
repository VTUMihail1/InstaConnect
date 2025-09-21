using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

using Mapster;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Mappings;

internal class UserClaimInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserClaimQueryEntity, UserClaim>()
              .ConstructUsing(uc => new(
                            uc.Id,
                            uc.Claim,
                            uc.Value,
                            uc.CreatedAt,
                            uc.UpdatedAt));
    }
}
