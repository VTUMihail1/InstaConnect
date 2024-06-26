using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using IdentityModel;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Users.Business.Commands.Account.EditAccount;
using InstaConnect.Users.Business.Commands.Account.RegisterAccount;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.User.GetAllUsers;
using InstaConnect.Users.Data.Models;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Users.Business.Profiles;

public class UsersBusinessProfile : Profile
{
    public UsersBusinessProfile()
    {
        // User

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

        CreateMap<EditAccountCommand, User>();

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
                new Claim(JwtClaimTypes.Subject, src.Id),
                new Claim(JwtClaimTypes.Email, src.Email),
                new Claim(JwtClaimTypes.GivenName, src.FirstName),
                new Claim(JwtClaimTypes.FamilyName, src.LastName),
                new Claim(JwtClaimTypes.Name, src.UserName)
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
