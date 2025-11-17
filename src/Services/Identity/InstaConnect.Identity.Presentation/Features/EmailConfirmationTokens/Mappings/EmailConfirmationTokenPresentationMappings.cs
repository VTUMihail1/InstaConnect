using AutoMapper;

using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Application.Features.Users.Models;

using Mapster;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddEmailConfirmationTokenApiRequest, AddEmailConfirmationTokenCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.Name)));

        config.NewConfig<VerifyEmailConfirmationTokenApiRequest, VerifyEmailConfirmationTokenCommandRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<EmailConfirmationTokenIdPayload>()));

        config.NewConfig<EmailConfirmationTokenIdApiPayload, EmailConfirmationTokenIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Value));

        config.NewConfig<EmailConfirmationTokenIdPayload, EmailConfirmationTokenIdApiPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdApiPayload>(),
                src.Value));
    }
}
