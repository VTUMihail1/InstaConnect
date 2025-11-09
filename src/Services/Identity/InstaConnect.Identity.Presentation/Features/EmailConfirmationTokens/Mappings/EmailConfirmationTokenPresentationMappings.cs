using AutoMapper;

using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenPresentationMappings : Profile
{
    public EmailConfirmationTokenPresentationMappings()
    {
        CreateMap<AddEmailConfirmationTokenApiRequest, AddEmailConfirmationTokenCommandRequest>()
            .ConstructUsing(src => new(src.Name));

        CreateMap<VerifyEmailConfirmationTokenApiRequest, VerifyEmailConfirmationTokenCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.Value));
    }
}
