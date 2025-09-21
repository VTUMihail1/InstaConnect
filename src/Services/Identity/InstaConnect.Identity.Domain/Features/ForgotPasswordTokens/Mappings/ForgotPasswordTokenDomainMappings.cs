using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Domain.Events.ForgotPasswordTokens;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

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
