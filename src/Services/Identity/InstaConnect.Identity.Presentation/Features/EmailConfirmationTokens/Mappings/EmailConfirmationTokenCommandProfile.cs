using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Application.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class EmailConfirmationTokenCommandProfile : Profile
{
    public EmailConfirmationTokenCommandProfile()
    {
        CreateMap<VerifyEmailConfirmationTokenRequest, VerifyEmailConfirmationTokenCommand>();

        CreateMap<AddEmailConfirmationTokenRequest, AddEmailConfirmationTokenCommand>();
    }
}
