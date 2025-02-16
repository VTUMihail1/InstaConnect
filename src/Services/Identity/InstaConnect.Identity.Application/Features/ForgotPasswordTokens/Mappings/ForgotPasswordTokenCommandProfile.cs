using AutoMapper;

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Emails;

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
