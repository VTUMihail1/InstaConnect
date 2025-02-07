using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Application.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class ForgotPasswordTokenCommandProfile : Profile
{
    public ForgotPasswordTokenCommandProfile()
    {
        CreateMap<AddForgotPasswordTokenRequest, AddForgotPasswordTokenCommand>();

        CreateMap<VerifyForgotPasswordTokenRequest, VerifyForgotPasswordTokenCommand>()
            .ConstructUsing(src => new(
                src.UserId,
                src.Token,
                src.Body.Password,
                src.Body.ConfirmPassword));
    }
}
