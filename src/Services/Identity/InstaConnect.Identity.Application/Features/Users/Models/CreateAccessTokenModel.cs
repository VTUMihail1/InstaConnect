using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

namespace InstaConnect.Identity.Application.Features.Users.Models;

public record CreateAccessTokenModel(
        string UserId,
        string Email,
        string FirstName,
        string LastName,
        string UserName,
        ICollection<UserClaim> UserClaims);


