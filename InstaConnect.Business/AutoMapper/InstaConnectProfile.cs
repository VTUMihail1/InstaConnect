using AutoMapper;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.AutoMapper
{
    public class InstaConnectProfile : Profile
    {
        public InstaConnectProfile()
        {
            CreateMap<User, AccountResultDTO>()
                .ReverseMap();

            CreateMap<AccountRegistrationDTO, User>()
                .ReverseMap();
        }
    }
}
