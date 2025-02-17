using AutoMapper;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenCommandProfile : Profile
{
    public ForgotPasswordTokenCommandProfile()
    {
        CreateMap<User, CreateForgotPasswordTokenModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email));

        CreateMap<GenerateForgotPasswordTokenResponse, ForgotPasswordToken>()
            .ConstructUsing(src => new(src.Value, src.ValidUntil, src.UserId));

        CreateMap<GenerateForgotPasswordTokenResponse, UserForgotPasswordTokenCreatedEvent>()
            .ConstructUsing(src => new(src.Email, src.RedirectUrl));
    }
}
