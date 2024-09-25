using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;

namespace InstaConnect.Identity.Business.Features.Accounts.Models;

public record CreateAccessTokenModel(
        string UserId,
        string Email,
        string FirstName,
        string LastName,
        string UserName,
        ICollection<UserClaim> UserClaims);


