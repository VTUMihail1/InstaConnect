﻿using System.Security.Claims;
using AutoMapper;
using CloudinaryDotNet.Actions;
using IdentityModel;
using InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;
using InstaConnect.Identity.Business.Commands.Account.RegisterAccount;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Identity.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Business.Profiles;

public class IdentityBusinessProfile : Profile
{
    public IdentityBusinessProfile()
    {
        // Users

        CreateMap<GetAllFilteredUsersQuery, UserFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new UserFilteredCollectionQuery
                 {
                     Expression = p => (src.UserName == string.Empty || p.UserName.Contains(src.UserName)) &&
                                       (src.FirstName == string.Empty || p.FirstName.Contains(src.UserName)) &&
                                       (src.LastName == string.Empty || p.LastName.Contains(src.UserName))
                 });

        CreateMap<GetAllUsersQuery, CollectionReadQuery>();

        CreateMap<RegisterAccountCommand, User>();

        CreateMap<EditCurrentAccountCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<Token, AccountViewModel>();

        CreateMap<Token, UserConfirmEmailTokenCreatedEvent>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Value));

        CreateMap<Token, UserForgotPasswordTokenCreatedEvent>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Value));

        CreateMap<User, UserConfirmEmailTokenCreatedEvent>();

        CreateMap<User, UserForgotPasswordTokenCreatedEvent>();

        CreateMap<PasswordHashResultModel, User>();

        CreateMap<User, UserViewModel>();

        CreateMap<User, UserDetailedViewModel>();

        CreateMap<User, GetUserByIdResponse>();

        CreateMap<User, UserDeletedEvent>();

        CreateMap<EditCurrentAccountProfileImageCommand, ImageUploadModel>()
            .ForMember(dest => dest.FormFile, opt => opt.MapFrom(src => src.ProfileImage));

        CreateMap<RegisterAccountCommand, ImageUploadModel>()
            .ForMember(dest => dest.FormFile, opt => opt.MapFrom(src => src.ProfileImage));

        CreateMap<ImageUploadResult, User>()
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.SecureUrl));

        // User claims

        CreateMap<User, CreateAccessTokenModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Claims, opt => opt.MapFrom(src =>
            new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, src.Id),
                new(ClaimTypes.Email, src.Email),
                new(ClaimTypes.GivenName, src.FirstName),
                new(ClaimTypes.Surname, src.LastName),
                new(ClaimTypes.Name, src.UserName)
            }));

        CreateMap<ICollection<UserClaim>, CreateAccessTokenModel>()
            .ForMember(dest => dest.Claims, opt => opt.MapFrom(src => src));

        CreateMap<User, CreateAccountTokenModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<User, UserClaimFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new UserClaimFilteredCollectionQuery
                 {
                     Expression = p => src.Id == p.UserId
                 });

        CreateMap<UserClaim, Claim>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.ValueType, opt => opt.MapFrom(src => src.Claim));
    }
}