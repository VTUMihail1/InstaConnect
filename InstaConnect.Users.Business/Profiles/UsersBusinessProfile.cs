using AutoMapper;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Users.Business.Commands.Account.EditAccount;
using InstaConnect.Users.Business.Commands.Account.RegisterAccount;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.User.GetAllUsers;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Users.Business.Profiles
{
    public class UsersBusinessProfile : Profile
    {
        public UsersBusinessProfile()
        {
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

            CreateMap<User, AccountViewDTO>();

            CreateMap<Token, TokenViewDTO>();

            CreateMap<TokenViewDTO, AccountViewDTO>();

            CreateMap<User, UserViewDTO>();

            CreateMap<User, UserDetailedViewDTO>();

            CreateMap<UserDetailsViewDTO, GetCurrentUserDetailsResponse>();
        }
    }
}
