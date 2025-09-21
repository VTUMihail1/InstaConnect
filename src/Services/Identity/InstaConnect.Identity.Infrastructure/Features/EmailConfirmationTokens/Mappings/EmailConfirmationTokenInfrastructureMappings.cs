using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;

using Mapster;

namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailConfirmationTokenQueryEntity, EmailConfirmationToken>()
              .ConstructUsing(u => new(
                            u.Id,
                            u.Value,
                            u.ExpiresAt,
                            u.CreatedAt,
                            u.UpdatedAt));
    }
}
