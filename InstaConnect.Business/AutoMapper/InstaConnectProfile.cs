using AutoMapper;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Token;
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

            CreateMap<AccountResultDTO, TokenGenerateDTO>()
                .ForMember(o => o.UserId, d => d.MapFrom(s => s.Id))
                .ReverseMap();

            CreateMap<TokenAddDTO, Token>()
                .ReverseMap();

            CreateMap<Token, TokenResultDTO>()
                .ReverseMap();
        }
    }
}
