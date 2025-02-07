using AutoMapper;
using CloudinaryDotNet.Actions;
using InstaConnect.Identity.Application.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Identity.Application.Features.Users.Mappings;

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
