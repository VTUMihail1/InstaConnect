using System.Security.Claims;
using AutoMapper;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;

namespace InstaConnect.Identity.Business.Features.Accounts.Mappings;

internal class UserClaimProfile : Profile
{
    public UserClaimProfile()
    {
        CreateMap<User, UserClaimFilteredCollectionWriteQuery>()
            .ConstructUsing(src => new(src.Id));

        CreateMap<UserClaim, Claim>()
            .ConstructUsing(src => new(src.Claim, src.Value));
    }
}
