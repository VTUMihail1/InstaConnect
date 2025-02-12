using AutoMapper;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Emails;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenCommandProfile : Profile
{
    public EmailConfirmationTokenCommandProfile()
    {
        CreateMap<User, CreateEmailConfirmationTokenModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email));

        CreateMap<GenerateEmailConfirmationTokenResponse, EmailConfirmationToken>()
            .ConstructUsing(src => new(src.Value, src.ValidUntil, src.UserId));

        CreateMap<GenerateEmailConfirmationTokenResponse, UserConfirmEmailTokenCreatedEvent>()
            .ConstructUsing(src => new(src.Email, src.RedirectUrl));
    }
}
