using System.Security.Claims;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.Tokens.Models;

public class CreateAccessTokenModel
{
    public CreateAccessTokenModel(string userId, string email, string firstName, string lastName, string userName, ICollection<UserClaim> otherUserClaims)
    {
        UserId = userId;
        Claims = [new(ClaimTypes.NameIdentifier, userId),
                  new(ClaimTypes.Email, email),
                  new(ClaimTypes.GivenName, firstName),
                  new(ClaimTypes.Surname, lastName),
                  new(ClaimTypes.Name, userName),
                  ..otherUserClaims.Select(uc => new Claim(uc.Claim, uc.Value))];
    }

    public string UserId { get; }

    public ICollection<Claim> Claims { get; }
}


