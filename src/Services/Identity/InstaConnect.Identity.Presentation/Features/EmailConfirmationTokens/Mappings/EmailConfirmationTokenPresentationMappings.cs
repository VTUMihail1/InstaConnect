using AutoMapper;

using InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Add;

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
