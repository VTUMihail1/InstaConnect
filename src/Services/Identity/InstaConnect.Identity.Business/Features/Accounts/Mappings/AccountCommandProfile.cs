using AutoMapper;
using CloudinaryDotNet.Actions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccountProfileImage;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Data.Features.Tokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Identity.Business.Features.Accounts.Mappings;

internal class AccountCommandProfile : Profile
{
    public AccountCommandProfile()
    {
        CreateMap<(PasswordHashResultModel, RegisterAccountCommand), User>()
            .ConstructUsing(src => new(
                src.Item2.FirstName,
                src.Item2.LastName,
                src.Item2.Email,
                src.Item2.UserName,
                src.Item1.PasswordHash,
                null!));

        CreateMap<EditCurrentAccountCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<Token, AccountTokenCommandViewModel>();

        CreateMap<(Token, User), UserConfirmEmailTokenCreatedEvent>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item1.Value));

        CreateMap<(Token, User), UserForgotPasswordTokenCreatedEvent>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item1.Value));

        CreateMap<User, UserDeletedEvent>();

        CreateMap<EditCurrentAccountProfileImageCommand, ImageUploadModel>()
            .ForMember(dest => dest.FormFile, opt => opt.MapFrom(src => src.ProfileImage));

        CreateMap<RegisterAccountCommand, ImageUploadModel>()
            .ForMember(dest => dest.FormFile, opt => opt.MapFrom(src => src.ProfileImage));

        CreateMap<ImageUploadResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.SecureUrl));

        CreateMap<User, AccountCommandViewModel>();
    }
}
