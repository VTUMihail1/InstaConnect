using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Mappings;

public class ForgotPasswordTokenApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddForgotPasswordTokenCommandRequest, AddForgotPasswordTokenCommand>()
            .ConstructUsing(src => new(src.Name.Adapt<Name>()));

        config.NewConfig<VerifyForgotPasswordTokenCommandRequest, VerifyForgotPasswordTokenCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<ForgotPasswordTokenId>(), src.Password, src.ConfirmPassword));

        config.NewConfig<ForgotPasswordTokenId, ForgotPasswordTokenIdPayload>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>(), src.Value));

        config.NewConfig<ForgotPasswordTokenIdPayload, ForgotPasswordTokenId>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>(), src.Value));
    }
}
