﻿using AutoMapper;
using CloudinaryDotNet.Actions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.Features.Accounts.Models.Options;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
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

        CreateMap<(ICollection<UserClaim>, User), CreateAccessTokenModel>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item2.FirstName, src.Item2.LastName, src.Item2.UserName, src.Item1));

        CreateMap<EditCurrentAccountCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<AccessTokenResult, AccountTokenCommandViewModel>();

        CreateMap<(EmailConfirmationToken, User, GatewayOptions), UserConfirmEmailTokenCreatedEvent>()
            .ConstructUsing(src => new(
                src.Item2.Email,
                src.Item2.Id,
                src.Item1.Value,
                src.Item3.Url,
                EmailConfigurations.EmailConfirmationUrlTemplate));

        CreateMap<(ForgotPasswordToken, User, GatewayOptions), UserForgotPasswordTokenCreatedEvent>()
            .ConstructUsing(src => new(
                src.Item2.Email,
                src.Item2.Id,
                src.Item1.Value,
                src.Item3.Url,
                EmailConfigurations.ForgotPasswordUrlTemplate));

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

        CreateMap<EditCurrentAccountCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImage!));

        CreateMap<RegisterAccountCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImage!));

        CreateMap<ImageUploadResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.SecureUrl));

        CreateMap<User, AccountCommandViewModel>();
    }
}
