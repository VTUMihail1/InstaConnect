using AutoMapper;
using InstaConnect.Identity.Data.Features.Tokens.Models;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;

namespace InstaConnect.Identity.Business.Features.Accounts.Mappings;

internal class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<User, CreateAccountTokenModel>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<(ICollection<UserClaim>, User), CreateAccessTokenModel>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item2.Email, src.Item2.FirstName, src.Item2.LastName, src.Item2.UserName, src.Item1));
    }
}
