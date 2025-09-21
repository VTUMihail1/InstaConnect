using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
public interface IAccessTokenGenerator
{
    AccessToken Generate(User user, ICollection<UserClaim> claims);
}
