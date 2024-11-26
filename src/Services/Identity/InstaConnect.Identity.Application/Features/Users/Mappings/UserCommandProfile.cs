﻿using AutoMapper;
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
            .ConstructUsing(src => new(src.ProfileImageFile!));

        CreateMap<RegisterUserCommand, ImageUploadModel>()
            .ConstructUsing(src => new(src.ProfileImage!));

        CreateMap<ImageUploadResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.SecureUrl));

        CreateMap<User, UserCommandViewModel>();

        CreateMap<GenerateEmailConfirmationTokenResponse, EmailConfirmationToken>()
            .ConstructUsing(src => new(src.Value, src.ValidUntil, src.UserId));

        CreateMap<GenerateEmailConfirmationTokenResponse, UserConfirmEmailTokenCreatedEvent>()
            .ConstructUsing(src => new(src.Email, src.RedirectUrl));

        CreateMap<GenerateForgotPasswordTokenResponse, ForgotPasswordToken>()
            .ConstructUsing(src => new(src.Value, src.ValidUntil, src.UserId));

        CreateMap<GenerateForgotPasswordTokenResponse, UserForgotPasswordTokenCreatedEvent>()
            .ConstructUsing(src => new(src.Email, src.RedirectUrl));
    }
}
