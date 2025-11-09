using AutoMapper;

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenPresentationMappings : Profile
{
    public ForgotPasswordTokenPresentationMappings()
    {
        CreateMap<AddForgotPasswordTokenApiRequest, AddForgotPasswordTokenCommandRequest>();

        CreateMap<VerifyForgotPasswordTokenApiRequest, VerifyForgotPasswordTokenCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.Value,
                src.Body.Password,
                src.Body.ConfirmPassword));
    }
}
