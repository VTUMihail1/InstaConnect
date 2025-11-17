using AutoMapper;

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;
using InstaConnect.Identity.Application.Features.Users.Models;

using Mapster;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddForgotPasswordTokenApiRequest, AddForgotPasswordTokenCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.Name)));

        config.NewConfig<VerifyForgotPasswordTokenApiRequest, VerifyForgotPasswordTokenCommandRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ForgotPasswordTokenIdPayload>(),
                src.Body.Password,
                src.Body.ConfirmPassword));

        config.NewConfig<ForgotPasswordTokenIdApiPayload, ForgotPasswordTokenIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Value));

        config.NewConfig<ForgotPasswordTokenIdPayload, ForgotPasswordTokenIdApiPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdApiPayload>(),
                src.Value));
    }
}
