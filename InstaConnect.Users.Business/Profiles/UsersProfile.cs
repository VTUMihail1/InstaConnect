using AutoMapper;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Users.Business.Commands.AccountRegister;
using InstaConnect.Users.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<AccountRegisterCommand, User>();

            CreateMap<User, AccountViewDTO>();
        }
    }
}
