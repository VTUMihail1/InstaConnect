using AutoMapper;
using InstaConnect.Users.Business.Commands.AccountEdit;
using InstaConnect.Users.Business.Commands.AccountRegister;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Business.Profiles
{
    public class UsersBusinessProfile : Profile
    {
        public UsersBusinessProfile()
        {
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
