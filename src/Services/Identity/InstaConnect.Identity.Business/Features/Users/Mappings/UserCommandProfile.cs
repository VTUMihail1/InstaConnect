using AutoMapper;
using CloudinaryDotNet.Actions;
using InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Models.Options;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Data.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Identity.Business.Features.Users.Mappings;

internal class UserCommandProfile : Profile
{
    public UserCommandProfile()
    {
        CreateMap<(PasswordHashResultModel, RegisterUserCommand), User>()
            .ConstructUsing(src => new(
                src.Item2.FirstName,
                src.Item2.LastName,
                src.Item2.Email,
                src.Item2.UserName,
                src.Item1.PasswordHash,
                null!));

        CreateMap<(ICollection<UserClaim>, User), CreateAccessTokenModel>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item2.FirstName, src.Item2.LastName, src.Item2.UserName, src.Item1));

        CreateMap<EditCurrentUserCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<AccessTokenResult, UserTokenCommandViewModel>();

        CreateMap<(EmailConfirmationToken, User, GatewayOptions), UserConfirmEmailTokenCreatedEvent>()
            .ConstructUsing(src => new(
                src.Item2.Email,
                src.Item2.Id,
                src.Item1.Value,
                src.Item3.UrlTemplate));

        CreateMap<(ForgotPasswordToken, User, GatewayOptions), UserForgotPasswordTokenCreatedEvent>()
            .ConstructUsing(src => new(
                src.Item2.Email,
                src.Item2.Id,
                src.Item1.Value,
                src.Item3.UrlTemplate));

        CreateMap<User, UserCreatedEvent>();

        CreateMap<User, UserUpdatedEvent>();

        CreateMap<User, UserDeletedEvent>();

        CreateMap<User, UserClaimCollectionWriteQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<User, CreateEmailConfirmationTokenModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email));

        CreateMap<User, CreateForgotPasswordTokenModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email));

        CreateMap<ImageResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ImageUri));

        CreateMap<EditCurrentUserCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImage!));

        CreateMap<RegisterUserCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImage!));

        CreateMap<ImageUploadResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.SecureUrl));

        CreateMap<User, UserCommandViewModel>();
    }
}
