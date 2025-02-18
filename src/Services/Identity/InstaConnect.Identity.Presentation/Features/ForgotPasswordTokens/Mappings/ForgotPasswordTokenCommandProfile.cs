using AutoMapper;

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Mappings;

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
