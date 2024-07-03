using System.Security.Claims;
using AutoMapper;
using IdentityModel;
using InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;
using InstaConnect.Identity.Business.Commands.Account.RegisterAccount;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Identity.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
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

        CreateMap<GetAllUsersQuery, CollectionQuery>();

        CreateMap<RegisterAccountCommand, User>();

        CreateMap<EditCurrentAccountCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<Token, AccountViewModel>();

        CreateMap<PasswordHashResultModel, User>();

        CreateMap<User, UserViewModel>();

        CreateMap<User, UserDetailedViewModel>();

        CreateMap<User, GetUserByIdResponse>();

        CreateMap<User, UserDeletedEvent>();

        // User claims

        CreateMap<User, CreateAccessTokenModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Claims, opt => opt.MapFrom(src =>
            new List<Claim>()
            {
                new(JwtClaimTypes.Subject, src.Id),
                new(JwtClaimTypes.Email, src.Email),
                new(JwtClaimTypes.GivenName, src.FirstName),
                new(JwtClaimTypes.FamilyName, src.LastName),
                new(JwtClaimTypes.Name, src.UserName)
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
