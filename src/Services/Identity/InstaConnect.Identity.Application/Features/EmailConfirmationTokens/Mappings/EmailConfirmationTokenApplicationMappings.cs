using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Mappings;

public class EmailConfirmationTokenApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<AddEmailConfirmationTokenCommandRequest, AddEmailConfirmationTokenCommand>()
            .ConstructUsing(src => new(src.Name.Adapt<Name>()));

        config.NewConfig<VerifyEmailConfirmationTokenCommandRequest, VerifyEmailConfirmationTokenCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<EmailConfirmationTokenId>()));

        config.NewConfig<EmailConfirmationTokenId, EmailConfirmationTokenIdPayload>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>(), src.Value));

        config.NewConfig<EmailConfirmationTokenIdPayload, EmailConfirmationTokenId>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>(), src.Value));
    }
}
