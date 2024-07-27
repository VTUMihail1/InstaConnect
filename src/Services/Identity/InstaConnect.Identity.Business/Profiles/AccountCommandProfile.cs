using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using CloudinaryDotNet.Actions;
using IdentityModel;
using InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;
using InstaConnect.Identity.Business.Commands.Account.RegisterAccount;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Identity.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Identity.Business.Profiles;

internal class AccountCommandProfile : Profile
{
    public AccountCommandProfile()
    {
        CreateMap<RegisterAccountCommand, User>();

        CreateMap<EditCurrentAccountCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<Token, AccountTokenCommandViewModel>();

        CreateMap<Token, UserConfirmEmailTokenCreatedEvent>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Value));

        CreateMap<Token, UserForgotPasswordTokenCreatedEvent>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Value));

        CreateMap<User, UserConfirmEmailTokenCreatedEvent>();

        CreateMap<User, UserForgotPasswordTokenCreatedEvent>();

        CreateMap<PasswordHashResultModel, User>();

        CreateMap<User, UserDeletedEvent>();

        CreateMap<EditCurrentAccountProfileImageCommand, ImageUploadModel>()
            .ForMember(dest => dest.FormFile, opt => opt.MapFrom(src => src.ProfileImage));

        CreateMap<RegisterAccountCommand, ImageUploadModel>()
            .ForMember(dest => dest.FormFile, opt => opt.MapFrom(src => src.ProfileImage));

        CreateMap<ImageUploadResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.SecureUrl));

        CreateMap<User, CreateAccountTokenModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<User, UserClaimFilteredCollectionWriteQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<(ICollection<UserClaim>, User), CreateAccessTokenModel>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item2.FirstName, src.Item2.LastName, src.Item2.UserName, src.Item1));

        CreateMap<UserClaim, Claim>()
            .ConstructUsing(src => new(src.Claim, src.Value));

        CreateMap<User, AccountCommandViewModel>();
    }
}
