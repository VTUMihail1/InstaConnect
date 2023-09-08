using AutoMapper;
using DocConnect.Business.Models.DTOs.Token;
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

            CreateMap<AccountResultDTO, TokenGenerateDTO>()
                .ReverseMap();

            CreateMap<TokenAddDTO, Token>()
                .ReverseMap();

            CreateMap<Token, TokenResultDTO>()
                .ReverseMap();
        }
    }
}
