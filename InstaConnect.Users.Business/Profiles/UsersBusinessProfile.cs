using AutoMapper;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Users.Business.Commands.AccountEdit;
using InstaConnect.Users.Business.Commands.AccountRegister;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Business.Queries.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.GetAllUsers;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Users.Business.Profiles
{
    public class UsersBusinessProfile : Profile
    {
        public UsersBusinessProfile()
        {
            CreateMap<GetAllFilteredUsersQuery, UserFilteredCollection>()
                .ConstructUsing(src =>
                     new UserFilteredCollection
                     {
                         Expression = p => (src.UserName == string.Empty || p.UserName.Contains(src.UserName)) &&
                                           (src.FirstName == string.Empty || p.FirstName.Contains(src.UserName)) &&
                                           (src.LastName == string.Empty || p.LastName.Contains(src.UserName))
                     });

            CreateMap<GetAllUsersQuery, CollectionQuery>();

            CreateMap<AccountRegisterCommand, User>();

            CreateMap<AccountEditCommand, User>();

            CreateMap<User, AccountViewDTO>();

            CreateMap<Token, TokenViewDTO>();

            CreateMap<TokenViewDTO, AccountViewDTO>();

            CreateMap<User, UserViewDTO>();

            CreateMap<User, UserDetailedViewDTO>();
        }
    }
}
