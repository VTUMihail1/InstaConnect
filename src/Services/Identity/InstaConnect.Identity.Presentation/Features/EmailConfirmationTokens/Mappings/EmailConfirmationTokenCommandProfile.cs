using AutoMapper;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenCommandProfile : Profile
{
    public EmailConfirmationTokenCommandProfile()
    {
        CreateMap<VerifyEmailConfirmationTokenRequest, VerifyEmailConfirmationTokenCommand>();

        CreateMap<AddEmailConfirmationTokenRequest, AddEmailConfirmationTokenCommand>();
    }
}
